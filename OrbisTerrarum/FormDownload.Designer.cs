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
    partial class FormDownload
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
			this.buttonStop = new System.Windows.Forms.Button();
			this.labelTotalBytes = new System.Windows.Forms.Label();
			this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
			this.labelTilesCnt = new System.Windows.Forms.Label();
			this.bgw = new System.ComponentModel.BackgroundWorker();
			this.labelTime = new System.Windows.Forms.Label();
			this.labelSpeed = new System.Windows.Forms.Label();
			this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonStop
			// 
			this.buttonStop.Location = new System.Drawing.Point(511, 128);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 0;
			this.buttonStop.Text = "Стоп";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// labelTotalBytes
			// 
			this.labelTotalBytes.AutoSize = true;
			this.labelTotalBytes.Location = new System.Drawing.Point(155, 102);
			this.labelTotalBytes.Name = "labelTotalBytes";
			this.labelTotalBytes.Size = new System.Drawing.Size(84, 13);
			this.labelTotalBytes.TabIndex = 1;
			this.labelTotalBytes.Text = "Получено байт:";
			// 
			// ProgressBar1
			// 
			this.ProgressBar1.Location = new System.Drawing.Point(12, 47);
			this.ProgressBar1.Name = "ProgressBar1";
			this.ProgressBar1.Size = new System.Drawing.Size(574, 23);
			this.ProgressBar1.TabIndex = 2;
			// 
			// labelTilesCnt
			// 
			this.labelTilesCnt.AutoSize = true;
			this.labelTilesCnt.Location = new System.Drawing.Point(155, 180);
			this.labelTilesCnt.Name = "labelTilesCnt";
			this.labelTilesCnt.Size = new System.Drawing.Size(99, 13);
			this.labelTilesCnt.TabIndex = 3;
			this.labelTilesCnt.Text = "Получено плиток: ";
			// 
			// labelTime
			// 
			this.labelTime.AutoSize = true;
			this.labelTime.Location = new System.Drawing.Point(155, 128);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new System.Drawing.Size(46, 13);
			this.labelTime.TabIndex = 4;
			this.labelTime.Text = "Время :";
			// 
			// labelSpeed
			// 
			this.labelSpeed.AutoSize = true;
			this.labelSpeed.Location = new System.Drawing.Point(155, 154);
			this.labelSpeed.Name = "labelSpeed";
			this.labelSpeed.Size = new System.Drawing.Size(58, 13);
			this.labelSpeed.TabIndex = 5;
			this.labelSpeed.Text = "Скорость:";
			// 
			// pictureBox1
			// 
			this.pictureBoxPreview.Location = new System.Drawing.Point(12, 86);
			this.pictureBoxPreview.Name = "pictureBox1";
			this.pictureBoxPreview.Size = new System.Drawing.Size(128, 128);
			this.pictureBoxPreview.TabIndex = 6;
			this.pictureBoxPreview.TabStop = false;
			// 
			// FormDownload
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(598, 248);
			this.ControlBox = false;
			this.Controls.Add(this.pictureBoxPreview);
			this.Controls.Add(this.labelSpeed);
			this.Controls.Add(this.labelTime);
			this.Controls.Add(this.labelTilesCnt);
			this.Controls.Add(this.ProgressBar1);
			this.Controls.Add(this.labelTotalBytes);
			this.Controls.Add(this.buttonStop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormDownload";
			this.ShowIcon = false;
			this.Text = "Загрузка данных";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelTotalBytes;
        private System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.Label labelTilesCnt;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.Label labelTime;
		private System.Windows.Forms.Label labelSpeed;
		private System.Windows.Forms.PictureBox pictureBoxPreview;
    }
}