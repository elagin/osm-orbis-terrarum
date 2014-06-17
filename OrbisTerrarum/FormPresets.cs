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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace orbis_terrarum
{
	public partial class FormPresets : Form
	{
		private DataTable _dt = new DataTable();
		private Settings _settings = new Settings();
		private Preset _newSet = new Preset();
		private int _select = 0;

		public int select;

		public FormPresets(ref Settings aSettings, Preset newSet, int select = 0)
		{
			InitializeComponent();

			_settings = aSettings;
			dataGridView.DataSource = _dt;
			_newSet = newSet;
			_select = select;
			initDataGridView();
		}

		/// <summary>
		/// Инициализирует dataGridView.</summary>
		private void initDataGridView()
		{
			_dt.Columns.Add("title", typeof(string));
			_dt.Columns.Add("sizeMeters", typeof(string));
			_dt.Columns.Add("layer", typeof(int));
			_dt.Columns.Add("lat", typeof(string));
			_dt.Columns.Add("lon", typeof(string));
			_dt.Columns.Add("mapWidth", typeof(int));
			_dt.Columns.Add("mapHeight", typeof(int));
			_dt.Columns.Add("date", typeof(DateTime));

			foreach (Preset element in _settings.Preset)
			{
				object[] arrTmp = new object[8];
				arrTmp[0] = element.Title;
				arrTmp[1] = element.sizeMeters;
				arrTmp[2] = element.Layer;
				arrTmp[3] = element.latLon.Lat;
				arrTmp[4] = element.latLon.Lon;
				arrTmp[5] = element.mapSize.Width;
				arrTmp[6] = element.mapSize.Height;
				arrTmp[7] = element.date;
				_dt.Rows.Add(arrTmp);
			}

			if (_newSet != null)
			{
				object[] arr = new object[8];
				arr[0] = _newSet.Title;
				arr[1] = _newSet.sizeMeters;
				arr[2] = _newSet.Layer;
				arr[3] = _newSet.latLon.Lat;
				arr[4] = _newSet.latLon.Lon;
				arr[5] = _newSet.mapSize.Width;
				arr[6] = _newSet.mapSize.Height;
				arr[7] = _newSet.date;
				_dt.Rows.Add(arr);
				dataGridView.Rows[dataGridView.RowCount - 1].Cells["title"].Selected = true;
			}
			else
			{
				dataGridView.Rows[_select].Cells["title"].Selected = true;
			}

			
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			List<Preset> res = new List<Preset>();
			foreach (DataGridViewRow item in dataGridView.Rows)
			{
				Preset set = new Preset();
				set.Title = item.Cells["title"].FormattedValue.ToString();
				set.sizeMeters = item.Cells["sizeMeters"].FormattedValue.ToString();
				set.Layer = Convert.ToInt32(item.Cells["layer"].FormattedValue);
				set.latLon = new GpsPoint(item.Cells["lat"].FormattedValue.ToString(), item.Cells["lon"].FormattedValue.ToString());
				set.date = Convert.ToDateTime(item.Cells["date"].FormattedValue);
				set.mapSize.Width = Convert.ToInt32(item.Cells["mapWidth"].FormattedValue);
				set.mapSize.Height = Convert.ToInt32(item.Cells["mapHeight"].FormattedValue);
				res.Add(set);
			}
			_settings.Preset = res;
			select = dataGridView.CurrentCell.RowIndex;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void buttonDeleteRow_Click(object sender, EventArgs e)
		{
			dataGridView.Rows.RemoveAt(dataGridView.CurrentCell.RowIndex);
		}
	}
}
