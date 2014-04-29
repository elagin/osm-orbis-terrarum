/*
 * Orbis Terrarum. Export OpenStreetMap tiles to OziExplorer map
 * Copyright © 2014 Pavel Elagin elagin.pasha@gmail.com

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
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace orbis_terrarum
{
	public partial class FormDownload : Form
	{
		/// <summary>
		/// Успешно ли завершена работа.</summary>
		public Boolean ReturnValue1 { get; set; }

		/// <summary>
		/// Менеджер плиток.</summary>
		private TileManager _tilesManager = null;
		private Rectangle _tilesRect = new Rectangle(0, 0, 0, 0);
		private int _zoom;

		/// <summary>
		/// Всего скачано байт.</summary>
		private int _bytesTotal;

		/// <summary>
		/// Сколько плиток нужно скачать.</summary>
		private int _tilesRemained;

		/// <summary>
		/// Плиток скачено.</summary>
		private int _tilesReady;

		/// <summary>
		/// Имя файла последней скачанной плитки.</summary>
		private string _fileName = "";

		/// <summary>
		/// Изображение последней скачанной плитки.</summary>
		private Bitmap _bmp = null;

		/// <summary>
		/// Таймер работы.</summary>
		private Stopwatch sWatch = new Stopwatch();

		/// <summary>
		/// Приключилась ли исключительная ситуация.</summary>
		private Boolean HaveException = false;

		public FormDownload(int zoom, Rectangle tilesRect, ref TileManager tiles)
		{
			InitializeComponent();

			ReturnValue1 = false;
			_zoom = zoom;
			_tilesRect = tilesRect;
			_tilesManager = tiles;
			pictureBoxPreview.SizeMode = PictureBoxSizeMode.StretchImage;

			bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
			bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
			bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
			bgw.WorkerReportsProgress = true;
			sWatch.Start();
			bgw.RunWorkerAsync();
		}

		/// <summary>
		/// Задача вторичного потока.</summary>
		void bgw_DoWork(object sender, DoWorkEventArgs e)
		{
			ProgressBar1.Value = 0;
			try
			{
				_tilesManager.getTiles(bgw, _tilesRect, _zoom);
			}
			catch (Exception ex)
			{
				const string caption = "Ошибка";
				var result = MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
				HaveException = true;
			}
		}

		/// <summary>
		/// Обновляет статистику.</summary>
		private void updateStat()
		{
			TimeSpan tSpan = sWatch.Elapsed;

			//примерно байт в плитке
			double bpt = _bytesTotal / _tilesReady;

			//примрно байт всего нужно скачать
			double totalBytesRemaind = _tilesRemained * bpt;

			//примерная средняя скорость
			double bps = _bytesTotal / tSpan.TotalSeconds;

			//секунд осталось работать
			double secondsRemained = totalBytesRemaind / bps;
			TimeSpan timeRemained = new TimeSpan(0, 0, (int)secondsRemained);

			labelTime.Text = "Время: " + tSpan.ToString(@"hh\:mm\:ss") + ", осталось: " + timeRemained.ToString(@"hh\:mm\:ss");
			labelSpeed.Text = String.Format("Скорость: {0:N0} кбайт./сек.", _bytesTotal / 1024 / tSpan.TotalSeconds);
			labelTotalBytes.Text = String.Format("Получено кбайт: {0:N0}, осталось: {1:N0}", _bytesTotal / 1024, totalBytesRemaind / 1024);
			labelTilesCnt.Text = String.Format("Плитки: {0}, осталось: {1}", _tilesReady, _tilesRemained);

			if (_fileName != null && _fileName.Length > 0)
			{
				if (_bmp != null)
					_bmp.Dispose();

				// Устраняет блокировку открытых файлов.
				using (var tmp = new Bitmap(_fileName))
				{
					_bmp = new Bitmap(tmp);
					pictureBoxPreview.Image = (Image)_bmp;
				}
			}
		}

		/// <summary>
		/// Событие изменения прогресс-бара.</summary>
		void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			ProgressBar1.Value = e.ProgressPercentage;
			DownloadState dState = (DownloadState)e.UserState;

			_bytesTotal = (int)dState.BytesTotal;
			_fileName = dState.FileName;
			_tilesReady = dState.TailReady;
			_tilesRemained = dState.TailTotal - dState.TailReady;
			updateStat();
		}

		/// <summary>
		/// Вторичный поток работу закончил.</summary>
		void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			TimeSpan tSpan = sWatch.Elapsed;
			sWatch.Stop();						// Останавливаем таймер
			labelTime.Text = "Время: " + tSpan.ToString(@"hh\:mm\:ss");
			labelTilesCnt.Text = String.Format("Плитки: {0}", _tilesReady);
			labelTotalBytes.Text = String.Format("Получено кбайт: {0:N0}", _bytesTotal / 1024);
			buttonStop.Text = "Закрыть";		// Меняем надпись на кнопке
		}

		/// <summary>
		/// Нажата кнопка остановить/закрыть.</summary>
		private void buttonStop_Click(object sender, EventArgs e)
		{
			if (!bgw.IsBusy && !HaveException)	// Если работа не выполняется и не было исключения, это корректное завершение.
				ReturnValue1 = true;			// Устанавливаем соответсвующий флаг.
			if (_bmp != null)
				_bmp.Dispose();
			this.Close();
		}
	}
}
