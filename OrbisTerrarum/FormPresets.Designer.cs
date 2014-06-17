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
namespace orbis_terrarum
{
	partial class FormPresets
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelUp = new System.Windows.Forms.Panel();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.panelDown = new System.Windows.Forms.Panel();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sizeMeters = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.layer = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lat = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lon = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mapWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mapHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buttonDeleteRow = new System.Windows.Forms.Button();
			this.panelUp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.panelDown.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelUp
			// 
			this.panelUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelUp.Controls.Add(this.dataGridView);
			this.panelUp.Location = new System.Drawing.Point(12, 12);
			this.panelUp.Name = "panelUp";
			this.panelUp.Size = new System.Drawing.Size(935, 260);
			this.panelUp.TabIndex = 0;
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToOrderColumns = true;
			this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title,
            this.sizeMeters,
            this.layer,
            this.lat,
            this.lon,
            this.mapWidth,
            this.mapHeight,
            this.date});
			this.dataGridView.Location = new System.Drawing.Point(0, 0);
			this.dataGridView.MultiSelect = false;
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(935, 260);
			this.dataGridView.TabIndex = 0;
			// 
			// panelDown
			// 
			this.panelDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelDown.Controls.Add(this.buttonDeleteRow);
			this.panelDown.Controls.Add(this.buttonCancel);
			this.panelDown.Controls.Add(this.buttonOk);
			this.panelDown.Location = new System.Drawing.Point(12, 278);
			this.panelDown.Name = "panelDown";
			this.panelDown.Size = new System.Drawing.Size(935, 38);
			this.panelDown.TabIndex = 1;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(491, 15);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(287, 15);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 0;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// title
			// 
			this.title.DataPropertyName = "title";
			this.title.HeaderText = "Название";
			this.title.Name = "title";
			// 
			// sizeMeters
			// 
			this.sizeMeters.DataPropertyName = "sizeMeters";
			this.sizeMeters.HeaderText = "Размер (м.)";
			this.sizeMeters.Name = "sizeMeters";
			this.sizeMeters.ReadOnly = true;
			// 
			// layer
			// 
			this.layer.DataPropertyName = "layer";
			this.layer.HeaderText = "Слой";
			this.layer.Name = "layer";
			this.layer.ReadOnly = true;
			// 
			// lat
			// 
			this.lat.DataPropertyName = "lat";
			this.lat.HeaderText = "Широта";
			this.lat.Name = "lat";
			this.lat.ReadOnly = true;
			// 
			// lon
			// 
			this.lon.DataPropertyName = "lon";
			this.lon.HeaderText = "Долгота";
			this.lon.Name = "lon";
			this.lon.ReadOnly = true;
			// 
			// mapWidth
			// 
			this.mapWidth.DataPropertyName = "mapWidth";
			this.mapWidth.HeaderText = "Ширина карты";
			this.mapWidth.Name = "mapWidth";
			// 
			// mapHeight
			// 
			this.mapHeight.DataPropertyName = "mapHeight";
			this.mapHeight.HeaderText = "Высота карты";
			this.mapHeight.Name = "mapHeight";
			// 
			// date
			// 
			this.date.DataPropertyName = "date";
			this.date.HeaderText = "Дата";
			this.date.Name = "date";
			this.date.ReadOnly = true;
			// 
			// buttonDeleteRow
			// 
			this.buttonDeleteRow.Location = new System.Drawing.Point(390, 15);
			this.buttonDeleteRow.Name = "buttonDeleteRow";
			this.buttonDeleteRow.Size = new System.Drawing.Size(75, 23);
			this.buttonDeleteRow.TabIndex = 2;
			this.buttonDeleteRow.Text = "Удалить";
			this.buttonDeleteRow.UseVisualStyleBackColor = true;
			this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
			// 
			// FormPresets
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(959, 328);
			this.Controls.Add(this.panelDown);
			this.Controls.Add(this.panelUp);
			this.Name = "FormPresets";
			this.Text = "FormPresets2";
			this.panelUp.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.panelDown.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelUp;
		private System.Windows.Forms.Panel panelDown;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.DataGridViewTextBoxColumn latLon;
		private System.Windows.Forms.DataGridViewTextBoxColumn title;
		private System.Windows.Forms.DataGridViewTextBoxColumn sizeMeters;
		private System.Windows.Forms.DataGridViewTextBoxColumn layer;
		private System.Windows.Forms.DataGridViewTextBoxColumn lat;
		private System.Windows.Forms.DataGridViewTextBoxColumn lon;
		private System.Windows.Forms.DataGridViewTextBoxColumn mapWidth;
		private System.Windows.Forms.DataGridViewTextBoxColumn mapHeight;
		private System.Windows.Forms.DataGridViewTextBoxColumn date;
		private System.Windows.Forms.Button buttonDeleteRow;
	}
}