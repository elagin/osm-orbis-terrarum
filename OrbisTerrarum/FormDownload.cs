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
				var result = MessageBox.Show(ex.Message, caption,
											 MessageBoxButtons.OK,
											 MessageBoxIcon.Error);
				HaveException = true;
			}
		}

		/// <summary>
		/// Событие изменения прогресс-бара.</summary>
		void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			ProgressBar1.Value = e.ProgressPercentage;
			DownloadState dState = (DownloadState)e.UserState;

			labelTotalBytes.Text = String.Format("Получено байт: {0}", dState.BytesTotal);
			labelTilesCnt.Text = String.Format("Получено плиток: {0}/{1}", dState.TailReady, dState.TailTotal);
			TimeSpan tSpan = sWatch.Elapsed;
			labelTime.Text = "Время: " + tSpan.ToString(@"hh\:mm\:ss");
		}

		/// <summary>
		/// Вторичный поток работу закончил.</summary>
		void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			sWatch.Stop();						// Останавливаем таймер
			buttonStop.Text = "Закрыть";		// Меняем надпись на кнопке
			TimeSpan tSpan = sWatch.Elapsed;
			labelTime.Text = "Время: " + tSpan.ToString(@"hh\:mm\:ss");
		}

		/// <summary>
		/// Нажата кнопка остановить/закрыть.</summary>
		private void buttonStop_Click(object sender, EventArgs e)
		{
			if (!bgw.IsBusy && !HaveException)	// Если работа не выполняется и не было исключения, это корректное завершение.
				ReturnValue1 = true;			// Устанавливаем соответсвующий флаг.
			this.Close();
		}
	}
}
