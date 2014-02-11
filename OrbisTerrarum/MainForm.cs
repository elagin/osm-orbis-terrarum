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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace orbis_terrarum
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Размер одной плитки в пикселах.</summary>

		/// <summary>
		/// Здесь храниться склееная карта.</summary>
		static Point _tileSize = new Point(256, 256);
		static Bitmap _bmp = null;

		/// <summary>
		/// Максимальный размер карты в пикселах.</summary>
		private Point _maxMapSize = new Point(_tileSize.X * 30, _tileSize.Y * 30);
		private Point _startPoint;

		/// <summary>
		/// Менеджер плиток.</summary>
		private TileManager tiles = new TileManager(_tileSize);								/// 

		/// <summary>
		/// Хранит настройки.</summary>
		private Settings settings = new Settings("config", new Point(_tileSize.X * 5, _tileSize.Y * 5));	// Настройки

		/// <summary>
		/// Настраивает элементы пользовательского интерфейса.</summary>
		private void fillCtrls()
		{
			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

			this.Text = String.Format("Orbis Terrarum v.{0}", fvi.FileVersion);

			for (int i = 1; i <= 19; i++)
				comboBoxZoom.Items.Add(new ComboItem(Convert.ToString(i), i));

			comboBoxLat.Items.Add(new ComboItem("N", 0));
			comboBoxLat.Items.Add(new ComboItem("S", 1));

			comboBoxLon.Items.Add(new ComboItem("E", 0));
			comboBoxLon.Items.Add(new ComboItem("W", 1));

			comboBoxZoom.SelectedIndex = settings.Zoom - 1;

			if (settings.CentralPoint.Lat > 0)
				comboBoxLat.SelectedIndex = 0;
			else
			{
				comboBoxLat.SelectedIndex = 1;
				settings.CentralPoint.Lat = settings.CentralPoint.Lat * -1;
			}

			if (settings.CentralPoint.Lon > 0)
				comboBoxLon.SelectedIndex = 0;
			else
			{
				comboBoxLon.SelectedIndex = 1;
				settings.CentralPoint.Lon = settings.CentralPoint.Lon * -1;
			}

			textBoxLat.Text = Convert.ToString(settings.CentralPoint.Lat);
			textBoxLon.Text = Convert.ToString(settings.CentralPoint.Lon);

			textBoxMapWidth.Text = Convert.ToString(settings.MapSize.Width);
			textBoxMapHeight.Text = Convert.ToString(settings.MapSize.Height);

			pictureBox1.Width = settings.MapSize.Width;
			pictureBox1.Height = settings.MapSize.Height;

			//Всегда в конце
			calcMapProperty();
		}

		/// Конструктор формы
		public MainForm()
		{
			InitializeComponent();
			fillCtrls();
		}

		/// <summary>
		/// Возвращает ширину карты заданную пользователем.</summary>
		private int getBoxMapWidth()
		{
			if (textBoxMapWidth.Text.Length > 0)
				return Convert.ToInt32(textBoxMapWidth.Text);
			else
				return 0;
		}

		/// <summary>
		/// Возвращает высоту карты заданную пользователем.</summary>
		private int getBoxMapHeight()
		{
			if (textBoxMapHeight.Text.Length > 0)
				return Convert.ToInt32(textBoxMapHeight.Text);
			else
				return 0;
		}

		/// <summary>
		/// Создает новое пространство.</summary>
		public void createPlace()
		{
			if (_bmp != null)
				_bmp = null;
			try
			{
				_bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format24bppRgb);
				Rectangle bmpRect = new Rectangle(0, 0, _bmp.Width, _bmp.Height);
				tiles.setBitmapRect(bmpRect);

				int pX = 0;
				int pY = 0;
				using (var canvas = Graphics.FromImage(_bmp))
				{
					canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
					for (int y = 0; pY < tiles.pixelsSize.Height; y += _tileSize.Y, pY++)
					{
						for (int x = 0; pX < tiles.pixelsSize.Width; x += _tileSize.X, pX++)
						{
							canvas.DrawImage(tiles.getBitmap(pX, pY),
								new Rectangle(x, y, _tileSize.X, _tileSize.Y),
								new Rectangle(0, 0, _tileSize.X, _tileSize.Y),
								GraphicsUnit.Pixel);
						}
						pX = 0; //Не забываем перевод строки
					}
					Point textPoint = new Point(pictureBox1.Width - 200, pictureBox1.Height - 20);
					drawText(canvas, "«© Участники OpenStreetMap»", textPoint, 10);
				}
			}
			catch (Exception ex)
			{
				const string caption = "Ошибка при создании нового пространства";
				var result = MessageBox.Show(ex.Message, caption,
											 MessageBoxButtons.OK,
											 MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Определяет плитки, которые нужно загрузить</summary>
		private Rectangle calcTiles()
		{
			/// Индекс центральной плитки
			PointF centerTile = Tools.worldToTilePos(settings.CentralPoint.Lon, settings.CentralPoint.Lat, settings.Zoom);

			/// Индекс первой плитки
			PointF firstTile = new PointF(centerTile.X - (tiles.pixelsSize.Width / 2), centerTile.Y - (tiles.pixelsSize.Height / 2));

			/// Плитки для загрузки
			return new Rectangle((int)firstTile.X, (int)firstTile.Y, tiles.pixelsSize.Width, tiles.pixelsSize.Height);
		}

		/// <summary>
		/// Загружает карту.</summary>
		private void buttonDownload_Click(object sender, EventArgs e)
		{
			try
			{
				SaveCtrls();

				/// Изменяем размер pictureBox1
				pictureBox1.Width = getBoxMapWidth();
				pictureBox1.Height = getBoxMapHeight();

				/// Изменяем размеры карты в плитках
				tiles.pixelsSize.Width = pictureBox1.Width / _tileSize.X;
				tiles.pixelsSize.Height = pictureBox1.Height / _tileSize.Y;

				/// Создаем форму для загрузки данных.
				using (FormDownload download = new FormDownload(settings.Zoom, calcTiles(), ref tiles))
				{
					DialogResult resDlg = download.ShowDialog();
					if (download.ReturnValue1) // Если данные усешно загружены
					{
						createPlace();
						labelMapSize.Text = String.Format("Размеры карты (м):\n {0:N0} x {1:N00}", tiles.mapSize.Width, tiles.mapSize.Height);
						textBoxTopGps.Text = tiles.gpsRect.Y.ToString();
						textBoxLeftGps.Text = tiles.gpsRect.X.ToString();
						textBoxRightGps.Text = (tiles.gpsRect.X + tiles.gpsRect.Height).ToString();
						textBoxBottomGps.Text = (tiles.gpsRect.Y + tiles.gpsRect.Width).ToString();

						tiles.mapScale = (double)tiles.mapSize.Width / getBoxMapWidth();
						labelMetPerPix.Text = String.Format("Метров на пиксел\n {0:N2}", tiles.mapScale);

						buttonSaveMap.Enabled = true;
					}
				}
				buttonDownload.Enabled = true;
				pictureBox1.Refresh();
			}
			catch (FormatException ex)
			{
				string caption = "Ошибка при загрузке данных";
				string msg = String.Format("{0} Пожалуйста, проверьте введенные данные.", ex.Message);
				var result = MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				string caption = "Ошибка при загрузке данных";
				var result = MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			Graphics lin = e.Graphics;
			drawTiles(lin, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width, e.ClipRectangle.Height);
		}

		private void drawText(Graphics lin, string text, Point point, int size)
		{
			//Font drawFont = new Font("Arial", 10);
			Font drawFont = new Font("Microsoft Sans Serif", size);
			SolidBrush drawBrush = new SolidBrush(Color.Black);
			//PointF drawPoint = new PointF(10.0F, 10.0F);
			StringFormat drawFormat = new StringFormat();
			//drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
			lin.DrawString(text, drawFont, drawBrush, point, drawFormat);
		}

		/// <summary>
		/// Склеивает карту из плиток.</summary>
		private void drawTiles(Graphics lin, int xClip, int yClip, int WidthClip, int heightClip)
		{
			if (_bmp != null)
			{
				try
				{
					using (var canvas = Graphics.FromImage(_bmp))
						lin.DrawImage(_bmp, 0, 0);
				}
				catch (Exception ex)
				{
					const string caption = "Произошла ошибка при склеивании карты";
					var result = MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void redraw_pictureBox1(object sender, EventArgs e)
		{
			pictureBox1.Refresh();
		}

		/// <summary>
		/// Диалог возвращающий имя файла для сохранения файла.</summary>
		private string getFilename()
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "png files (*.png)|*.png";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK)
				return dlg.FileName;
			else
				return "";
		}

		/// <summary>
		/// Сохраняет карту в файлы.</summary>
		private void buttonSaveMap_Click(object sender, EventArgs e)
		{
			try
			{
				string file_name = getFilename();
				if (file_name.Length > 0)
				{
					_bmp.Save(file_name, ImageFormat.Png);
					tiles.saveMapfile(file_name);
				}
			}
			catch (Exception ex)
			{
				const string caption = "Произошла ошибка при сохранении карты.";
				var result = MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void panel1_Scroll(object sender, ScrollEventArgs e)
		{
			btn_redraw_Click(sender, e);
		}

		/// <summary>
		/// Предварительный расчет загружаемового объема.</summary>
		private void calcMapProperty()
		{
			int boxMapWidth = getBoxMapWidth() / _tileSize.X;
			int boxMapHeight = getBoxMapHeight() / _tileSize.Y;
			labelTilesRect.Text = String.Format("Плитки:\n {0} x {1} = {2}", boxMapWidth, boxMapHeight, boxMapWidth * boxMapHeight);
		}

		/// <summary>
		/// Уменьшает ширину карты.</summary>
		private void buttonMapWidthDec_Click(object sender, EventArgs e)
		{
			int boxMapWidth = getBoxMapWidth();
			if (boxMapWidth > _tileSize.X * 2)
			{
				boxMapWidth -= _tileSize.X; // Изменяем в соответствии с размером плитки.
				textBoxMapWidth.Text = Convert.ToString(boxMapWidth);
				buttonMapWidthInc.Enabled = true;
				calcMapProperty();
			}
			else
			{
				buttonMapWidthDec.Enabled = false; // Блокируем, что бы не привысить ограничение
			}
		}

		/// <summary>
		/// Увеличивает ширину карты.</summary>
		private void buttonMapWidthInc_Click(object sender, EventArgs e)
		{
			int boxMapWidth = getBoxMapWidth();
			if (boxMapWidth < _maxMapSize.X)
			{
				boxMapWidth += _tileSize.X;
				textBoxMapWidth.Text = Convert.ToString(boxMapWidth);
				buttonMapWidthDec.Enabled = true;
				calcMapProperty();
			}
			else
			{
				buttonMapWidthInc.Enabled = false;
			}
		}

		/// <summary>
		/// Уменьшает высоту карты.</summary>
		private void buttonMapHeightDec_Click(object sender, EventArgs e)
		{
			int boxMapHeight = getBoxMapHeight();
			if (boxMapHeight > _tileSize.Y * 2)
			{
				boxMapHeight -= _tileSize.Y;
				textBoxMapHeight.Text = Convert.ToString(boxMapHeight);
				buttonMapHeightInc.Enabled = true;
				calcMapProperty();
			}
			else
			{
				buttonMapHeightDec.Enabled = false;
			}
		}

		/// <summary>
		/// Увеличивает высоту карты.</summary>
		private void buttonMapHeightInc_Click(object sender, EventArgs e)
		{
			int boxMapHeight = getBoxMapHeight();
			if (boxMapHeight < _maxMapSize.Y)
			{
				boxMapHeight += _tileSize.Y;
				textBoxMapHeight.Text = Convert.ToString(boxMapHeight);
				buttonMapHeightDec.Enabled = true;
				calcMapProperty();
			}
			else
			{
				buttonMapHeightInc.Enabled = false;
			}
		}

		private void btn_redraw_Click(object sender, EventArgs e)
		{
			pictureBox1.Refresh();
		}

		/// <summary>
		/// Сохраняет состояния элементов UI.</summary>
		private void SaveCtrls()
		{
			double lat = 0;
			double lon = 0;

			if (textBoxLat.Text.Length > 0)
			{
				lat = Convert.ToDouble(textBoxLat.Text);
				if (comboBoxLat.SelectedIndex == 0)
					settings.CentralPoint.Lat = (float)lat;
				else
					settings.CentralPoint.Lat = -(float)lat;
			}
			if (textBoxLon.Text.Length > 0)
			{
				lon = Convert.ToDouble(textBoxLon.Text);
				if (comboBoxLon.SelectedIndex == 0)
					settings.CentralPoint.Lon = (float)lon;
				else
					settings.CentralPoint.Lon = -(float)lon;
			}
			settings.Zoom = getZoom();
			settings.MapSize.Width = getBoxMapWidth();
			settings.MapSize.Height = getBoxMapHeight();
		}

		/// <summary>
		/// Подготовка к закрытию формы.</summary>
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveCtrls();
			settings.save();
		}

		private void textBoxLat_TextChanged(object sender, EventArgs e)
		{
			buttonDownload.Enabled = textBoxLat.Text.Length > 0 && textBoxLon.Text.Length > 0;
		}

		private void textBoxLon_TextChanged(object sender, EventArgs e)
		{
			buttonDownload.Enabled = textBoxLat.Text.Length > 0 && textBoxLon.Text.Length > 0;
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			Point changePoint = new Point(e.Location.X - _startPoint.X,
										  e.Location.Y - _startPoint.Y);
			if (e.Button == MouseButtons.Left) // Если нажата левая кнопка мыши - скроллируем окно
			{
				panel1.AutoScrollPosition = new Point(-panel1.AutoScrollPosition.X - changePoint.X,
													  -panel1.AutoScrollPosition.Y - changePoint.Y);
			}
			else // Иначе отображаем координаты в статус-баре.
			{
				float xPos = ((tiles.gpsRect.Width / pictureBox1.Width) * e.Location.X) + tiles.gpsRect.Left;
				float yPos = ((tiles.gpsRect.Height / pictureBox1.Height) * e.Location.Y) + tiles.gpsRect.Top;
				toolStripStatusLabel1.Text = String.Format("{0} x {1}", yPos, xPos);
				statusStrip1.Refresh();
			}
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				_startPoint = e.Location;
		}

		private int getZoom()
		{
			ComboItem item = (ComboItem)comboBoxZoom.SelectedItem;
			return item.Value;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			settings.Zoom = getZoom();
			calcMapProperty();
		}

		/// <summary>
		/// Класс для хранения элементов ComboBox.</summary>
		private class ComboItem
		{
			public string Name;
			public int Value;

			public ComboItem(string name, int value)
			{
				Name = name; Value = value;
			}

			public override string ToString()
			{
				/// <summary>
				///  Generates the text shown in the combo box.</summary>
				return Name;
			}
		}

		private void buttonAbout_Click(object sender, EventArgs e)
		{
			using (FormAbout about = new FormAbout())
			{
				DialogResult resDlg = about.ShowDialog();
			}
		}
	}
}
