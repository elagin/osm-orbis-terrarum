/*
 * Orbis Terrarum. Export OpenStreetMap tiles to OziExplorer map
 * Copyright © 2014 Pavel Elagin

 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <www.gnu.org/licenses/>
 * 
 * Source code: https://github.com/elagin/osm-orbis-terrarum
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Globalization;

namespace orbis_terrarum
{

	/// <summary>
	/// Класс для хранения статистики по скачиванию плиток.</summary>
	public class DownloadState
	{
		public DownloadState(int tailTotal)
		{
			TailTotal = tailTotal;
		}

		public int TailTotal { get; set; }
		public int TailReady { get; set; }
		public UInt64 BytesTotal { get; set; }
	}

	/// <summary>
	/// Класс для хранения плитки.</summary>
	public class Tile
	{
		public Tile(string name)
		{
			Bmp = new Bitmap(name);
			parceName(name);
		}

		public Tile(string name, Bitmap bmp)
		{
			Bmp = bmp;
			parceName(name);
		}

		/// <summary>
		/// Из имени файла извлекает номер плитки, масштаб.</summary>
		private void parceName(string name)
		{
			int start_ptr = name.LastIndexOf('\\');
			start_ptr = name.LastIndexOf('\\', start_ptr - 1);
			string short_name = name.Substring(start_ptr + 1);

			start_ptr = short_name.IndexOf('\\', 0);
			Zoom = Convert.ToInt32(short_name.Substring(0, start_ptr));

			int end_ptr = short_name.IndexOf('-', start_ptr + 1);
			long x = Convert.ToInt64(short_name.Substring(start_ptr + 1, end_ptr - start_ptr - 1));

			start_ptr = short_name.IndexOf('.', end_ptr);
			int y = Convert.ToInt32(short_name.Substring(end_ptr + 1, start_ptr - end_ptr - 1));
			Index = new Point((int)x, y);
		}

		public Bitmap Bmp { get; set; }
		public string Name { get; set; }
		public Point Index { get; set; }
		public int Zoom { get; set; }
	}

	/// <summary>
	/// Диспечер плиток.</summary>
	public class TileManager
	{
		/// <summary>
		/// Размеры карты в метрах.</summary>
		public Size mapSize = new Size();

		/// <summary>
		/// Габариты карты в географических координатах.</summary>
		public RectangleF gpsRect = new RectangleF();

		/// <summary>
		/// Размеры карты в плитках.</summary>
		public Size pixelsSize = new Size(0, 0);

		/// <summary>
		/// Масштаб карты (Метров в пикселе)</summary>
		public double mapScale = 0;

		/// <summary>
		/// Размер одной плитки в пикселах.</summary>
		private Point _tileSize = new Point(0, 0);

		/// <summary>
		/// Картинка для плитки, которую не удалось загрузить</summary>
		private Bitmap _bmp404 = null;

		/// <summary>
		/// Плитки содержащие карту</summary>
		private Tile[,] _tiles = null;

		/// <summary>
		/// Габариты изображения карты.</summary>
		private Rectangle _bmpRect;

		public TileManager(Point size)
		{
			_tileSize = size;
		}

		//Задаем новый размер карты
		public void setBitmapRect(Rectangle bmpRect)
		{
			_bmpRect = bmpRect;
		}

		/// <summary>
		/// Возвращает изображение нужной плитки.</summary>
		/// <param name="x">Номер плитки по горизонтали</param>
		/// <param name="y">Номер плитки по вертикали</param>
		//// <returns>Возвращает изображение нужной плитки.</returns>
		public Bitmap getBitmap(int x, int y)
		{
			return _tiles[x, y].Bmp;
		}

		/// <summary>
		/// Получает новые плитки.</summary>
		public void getTiles(BackgroundWorker bgw, Rectangle tiles, int zoom)
		{
			List<string> files = downloadTiles(bgw, tiles.X, tiles.Y, tiles.Width, tiles.Height, zoom);
			loadTiles(files);
		}

		/// <summary>
		/// Скачивает нужные плитки, если они отсутствуют в кэше или если срок хранения истек.</summary>
		private List<string> downloadTiles(BackgroundWorker bgw, int x, int y, int cnt_x, int cnt_y, int zoom)
		{
			List<string> files = new List<string>();
			string root_url = @"http://a.tile.openstreetmap.org/";
			string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
			int tiles_pos = path.LastIndexOf('\\');
			path = path.Remove(tiles_pos + 1) + "cache\\" + Convert.ToString(zoom) + "\\";
			DownloadState _dState = new DownloadState(cnt_x * cnt_y);

			for (int _y = y; _y < cnt_y + y; _y++)
			{
				for (int _x = x; _x < cnt_x + x; _x++)
				{
					//Thread.Sleep(1000);
					string url_file_name = String.Format("{0}/{1}/{2}.png", zoom, _x, _y);
					string file_name = String.Format("{0}-{1}.png", _x, _y);
					string url = root_url + url_file_name;
					file_name = path + file_name;

					// Нужно ли скачивать файл из сети.
					if (isExpires(file_name))
					{
						using (WebClient wc = new WebClient())
						{
							try
							{
								byte[] fileBytes = wc.DownloadData(url);
								string fileType = wc.ResponseHeaders[HttpResponseHeader.ContentType];

								if (fileType != null)
								{
									//switch (fileType)
									//{
									//    case "image/png":
									//        file_name = path + file_name + ".png";
									//        break;
									//    default:
									//        break;
									//}
									try
									{
										System.IO.File.WriteAllBytes(file_name, fileBytes);
									}
									catch (DirectoryNotFoundException dirEx)
									{	// Если директория не существует, создаем и пробуем сохранить еще раз.
										System.IO.Directory.CreateDirectory(path);
										System.IO.File.WriteAllBytes(file_name, fileBytes);
									}
									_dState.BytesTotal += Convert.ToUInt64(wc.ResponseHeaders[HttpResponseHeader.ContentLength]);
								}
							}
							catch (WebException we)
							{
								// Ни чего страшного, загрузим в следующий раз, а пока вставим квадрат Малевича.
							}
						}
					}
					files.Add(file_name); // Добавляем имя файла для последующей загрузки с диска.
					_dState.TailReady++;
					int percents = (_dState.TailReady * 100) / _dState.TailTotal;
					bgw.ReportProgress(percents, _dState);  // Обновляем информацию в форме.
				}
			}
			return files;
		}

		/// <summary>
		/// Загружает плитки из дискового кэша.</summary>
		private void loadTiles(List<string> names)
		{
			if (_tiles != null)
				_tiles = null;

			_tiles = new Tile[pixelsSize.Width, pixelsSize.Height];
			int pos = 0;
			for (int y = 0; y < pixelsSize.Height; y++)
			{
				for (int x = 0; x < pixelsSize.Width; x++)
				{
					Tile tmp = null;
					try
					{
						tmp = new Tile(names[pos]);
					}
					catch (Exception ex)
					{	// Вероятно файл не был скачан, вставляем заглушку
						if (_bmp404 == null)
							_bmp404 = createErrorBitmap();
						tmp = new Tile(names[pos], _bmp404);
					}
					_tiles[x, y] = tmp;

					if (x == 0 && y == 0) // Если это левая верхняя плитка, запоминаем координату левого верхнего ее угла
					{
						PointF left_top = Tools.tileToWorldPos(tmp.Index, tmp.Zoom);
						gpsRect.X = left_top.X;
						gpsRect.Y = left_top.Y;
					}
					pos++;
				}
			}

			// Вычисляем индекс правой нижней плитки.
			PointF lastTile = _tiles[pixelsSize.Width - 1, pixelsSize.Height - 1].Index;
			lastTile.X++;
			lastTile.Y++;

			// Запоминаем координату правого нижнего угла правой нижней плитки.
			PointF right_bottom = Tools.tileToWorldPos(lastTile, _tiles[pixelsSize.Width - 1, pixelsSize.Height - 1].Zoom);
			gpsRect.Width = right_bottom.X - gpsRect.X;
			gpsRect.Height = right_bottom.Y - gpsRect.Y;

			mapSize.Width = (int)Tools.calcDist(gpsRect.Y, gpsRect.X, gpsRect.Y + gpsRect.Height, gpsRect.X);
			mapSize.Height = (int)Tools.calcDist(gpsRect.Y, gpsRect.X, gpsRect.Y, gpsRect.X + gpsRect.Width);
		}

		/// <summary>
		/// Проверяет есть ли файл в кэше и не истек ли срок его хранения.</summary>
		private Boolean isExpires(string fileName)
		{
			if (System.IO.File.Exists(fileName)) // Если файл сущетсвует
			{
				DateTime fileCreatedDate = System.IO.File.GetCreationTime(fileName);
				TimeSpan myDateResult = DateTime.Now - fileCreatedDate;
				return myDateResult.Days > 7; // старее 7 суток
			}
			return true;
			//var dt1 = DateTime.Parse("Fri, 31 Jan 2014 04:34:14 GMT");
			//return dt1 < DateTime.Now;
		}

		/// <summary>
		// Сохраняет map-файла.</summary>
		// http://androzic.com/wiki/ru/OziExplorer/Maps.html
		public void saveMapfile(string name)
		{
			//Разделитель должен быть только "точкой".
			CultureInfo culture;
			culture = CultureInfo.CreateSpecificCulture("en-CA");
			string topMin = String.Format(culture, "{0}", Tools.grad_to_min(gpsRect.Top));
			string bottomMin = String.Format(culture, "{0}", Tools.grad_to_min(gpsRect.Bottom));
			string LeftMin = String.Format(culture, "{0}", Tools.grad_to_min(gpsRect.Left));
			string rightMin = String.Format(culture, "{0}", Tools.grad_to_min(gpsRect.Right));

			string top = String.Format(culture, "{0}", gpsRect.Top);
			string bottom = String.Format(culture, "{0}", gpsRect.Bottom);
			string left = String.Format(culture, "{0}", gpsRect.Left);
			string right = String.Format(culture, "{0}", gpsRect.Right);

			string header1 = "OziExplorer Map Data File Version 2.2";
			string header2 = "1 ,Map Code,\r\nWGS 84,WGS 84,   0.0000,   0.0000,WGS 84\r\nReserved 1\r\nReserved 2\r\nMagnetic Variation,,,E\r\nMap Projection,Mercator,PolyCal,No,AutoCalOnly,No,BSBUseWPX,No";

			string Point01 = String.Format("Point01,xy,    {0},    {1},in, deg,  {2}, {3},N,  {4}, {5},E, grid,   ,           ,           ,N",
			0, 0, (int)gpsRect.Top, topMin, (int)gpsRect.Left, LeftMin);

			string Point02 = String.Format("Point02,xy,    {0},    {1},in, deg,  {2}, {3},N,  {4}, {5},E, grid,   ,           ,           ,N",
			_bmpRect.Width, 0, (int)gpsRect.Top, topMin, (int)gpsRect.Right, rightMin);

			string Point03 = String.Format("Point03,xy,    {0},    {1},in, deg,  {2}, {3},N,  {4}, {5},E, grid,   ,           ,           ,N",
			_bmpRect.Width, _bmpRect.Height, (int)gpsRect.Bottom, bottomMin, (int)gpsRect.Right, rightMin);

			string Point04 = String.Format("Point04,xy,    {0},    {1},in, deg,  {2}, {3},N,  {4}, {5},E, grid,   ,           ,           ,N",
			0, _bmpRect.Height, (int)gpsRect.Bottom, bottomMin, (int)gpsRect.Left, LeftMin);

			//todo: Посмотреть на других локалях
			using (StreamWriter file = new StreamWriter(name + ".map", false, Encoding.GetEncoding("Windows-1251")))
			{
				file.WriteLine(header1);

				int start_ptr = name.LastIndexOf('\\');
				string short_name = name.Substring(start_ptr + 1);

				file.WriteLine(short_name);
				file.WriteLine(short_name);

				file.WriteLine(header2);
				file.WriteLine(Point01);
				file.WriteLine(Point02);
				file.WriteLine(Point03);
				file.WriteLine(Point04);

				for (int i = 5; i < 10; i++)
				{
					string Point0x = String.Format("Point0{0},xy, , ,in, deg, , ,N, , , E, grid, , , ,N", i);
					file.WriteLine(Point0x);
				}

				for (int i = 10; i <= 30; i++)
				{
					string Point0x = String.Format("Point{0},xy, , ,in, deg, , ,N, , , E, grid, , , ,N", i);
					file.WriteLine(Point0x);
				}

				string proj = "Projection Setup,     0.000000000,    45.000000000,     1.000000000,       500000.00,            0.00,,,,,";
				string text1 = "Map Feature = MF ; Map Comment = MC     These follow if they exist\r\nTrack File = TF      These follow if they exist\r\nMoving Map Parameters = MM?    These follow if they exist";
				file.WriteLine(proj);
				file.WriteLine(text1);

				string mm = "MM0,Yes";
				file.WriteLine(mm);

				string bp_cnt = "MMPNUM,4";
				file.WriteLine(bp_cnt);

				file.WriteLine(String.Format("MMPXY,1,{0},{1}", 0, 0));
				file.WriteLine(String.Format("MMPXY,2,{0},{1}", _bmpRect.Width, 0));
				file.WriteLine(String.Format("MMPXY,3,{0},{1}", _bmpRect.Width, _bmpRect.Height));
				file.WriteLine(String.Format("MMPXY,4,{0},{1}", 0, _bmpRect.Height));

				file.WriteLine(String.Format("MMPLL,1,  {0}, {1}", left, top));
				file.WriteLine(String.Format("MMPLL,2,  {0}, {1}", right, top));
				file.WriteLine(String.Format("MMPLL,3,  {0}, {1}", right, bottom));
				file.WriteLine(String.Format("MMPLL,4,  {0}, {1}", left, bottom));

				file.WriteLine(String.Format(culture, "MM1B,{0}", mapScale));
				file.WriteLine("MOP,Map Open Position,0,0");
				file.WriteLine(String.Format("IWH,Map Image Width/Height,{0}, {1}", _bmpRect.Width, _bmpRect.Height));
			}
		}

		/// <summary>
		// Создает плитку, которая не была скачана.</summary>
		private Bitmap createErrorBitmap()
		{
			Bitmap bmp404 = new Bitmap(_tileSize.X, _tileSize.Y);
			Point p = new Point(_tileSize.X / 2, _tileSize.Y / 2);
			
			Pen redPen = new Pen(Color.Red, 1);
			using (var canvas = Graphics.FromImage(bmp404))
			{
				canvas.DrawLine(redPen, 0, 0, _tileSize.X, _tileSize.Y);
				canvas.DrawLine(redPen, _tileSize.X, 0, 0, _tileSize.Y);
			}
			//draw_text(bmp404, "404", p);
			return bmp404;
		}
	}
}
