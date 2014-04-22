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
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.buttonDownload = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.textBoxLat = new System.Windows.Forms.TextBox();
			this.textBoxLon = new System.Windows.Forms.TextBox();
			this.textBoxMapWidth = new System.Windows.Forms.TextBox();
			this.textBoxMapHeight = new System.Windows.Forms.TextBox();
			this.buttonMapHeightInc = new System.Windows.Forms.Button();
			this.buttonMapHeightDec = new System.Windows.Forms.Button();
			this.buttonMapWidthInc = new System.Windows.Forms.Button();
			this.buttonMapWidthDec = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboBoxLon = new System.Windows.Forms.ComboBox();
			this.comboBoxLat = new System.Windows.Forms.ComboBox();
			this.comboBoxZoom = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonSaveMap = new System.Windows.Forms.Button();
			this.buttonAbout = new System.Windows.Forms.Button();
			this.labelMapSize = new System.Windows.Forms.Label();
			this.textBoxTopGps = new System.Windows.Forms.TextBox();
			this.textBoxLeftGps = new System.Windows.Forms.TextBox();
			this.textBoxRightGps = new System.Windows.Forms.TextBox();
			this.textBoxBottomGps = new System.Windows.Forms.TextBox();
			this.labelTilesRect = new System.Windows.Forms.Label();
			this.labelMetPerPix = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mapCenteroolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonDownload
			// 
			this.buttonDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDownload.Location = new System.Drawing.Point(28, 113);
			this.buttonDownload.Name = "buttonDownload";
			this.buttonDownload.Size = new System.Drawing.Size(75, 23);
			this.buttonDownload.TabIndex = 1;
			this.buttonDownload.Text = "Загрузить";
			this.buttonDownload.UseVisualStyleBackColor = true;
			this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Location = new System.Drawing.Point(13, 13);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(866, 630);
			this.panel1.TabIndex = 2;
			this.panel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel1_Scroll);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.pictureBox1.Location = new System.Drawing.Point(4, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(1024, 768);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.LocationChanged += new System.EventHandler(this.btn_redraw_Click);
			this.pictureBox1.RegionChanged += new System.EventHandler(this.btn_redraw_Click);
			this.pictureBox1.VisibleChanged += new System.EventHandler(this.btn_redraw_Click);
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.pictureBox1.Move += new System.EventHandler(this.btn_redraw_Click);
			this.pictureBox1.ParentChanged += new System.EventHandler(this.btn_redraw_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 646);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1022, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(24, 17);
			this.toolStripStatusLabel1.Text = "0x0";
			// 
			// textBoxLat
			// 
			this.textBoxLat.Location = new System.Drawing.Point(9, 36);
			this.textBoxLat.Name = "textBoxLat";
			this.textBoxLat.Size = new System.Drawing.Size(67, 20);
			this.textBoxLat.TabIndex = 7;
			this.textBoxLat.TextChanged += new System.EventHandler(this.textBoxLat_TextChanged);
			// 
			// textBoxLon
			// 
			this.textBoxLon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLon.Location = new System.Drawing.Point(9, 78);
			this.textBoxLon.Name = "textBoxLon";
			this.textBoxLon.Size = new System.Drawing.Size(67, 20);
			this.textBoxLon.TabIndex = 8;
			this.textBoxLon.TextChanged += new System.EventHandler(this.textBoxLon_TextChanged);
			// 
			// textBoxMapWidth
			// 
			this.textBoxMapWidth.Location = new System.Drawing.Point(39, 34);
			this.textBoxMapWidth.Name = "textBoxMapWidth";
			this.textBoxMapWidth.ReadOnly = true;
			this.textBoxMapWidth.Size = new System.Drawing.Size(45, 20);
			this.textBoxMapWidth.TabIndex = 9;
			this.textBoxMapWidth.Text = "1024";
			// 
			// textBoxMapHeight
			// 
			this.textBoxMapHeight.Location = new System.Drawing.Point(39, 76);
			this.textBoxMapHeight.Name = "textBoxMapHeight";
			this.textBoxMapHeight.ReadOnly = true;
			this.textBoxMapHeight.Size = new System.Drawing.Size(45, 20);
			this.textBoxMapHeight.TabIndex = 10;
			this.textBoxMapHeight.Text = "1024";
			// 
			// buttonMapHeightInc
			// 
			this.buttonMapHeightInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonMapHeightInc.Location = new System.Drawing.Point(90, 74);
			this.buttonMapHeightInc.Name = "buttonMapHeightInc";
			this.buttonMapHeightInc.Size = new System.Drawing.Size(23, 23);
			this.buttonMapHeightInc.TabIndex = 14;
			this.buttonMapHeightInc.Text = "+";
			this.buttonMapHeightInc.UseVisualStyleBackColor = true;
			this.buttonMapHeightInc.Click += new System.EventHandler(this.buttonMapHeightInc_Click);
			// 
			// buttonMapHeightDec
			// 
			this.buttonMapHeightDec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonMapHeightDec.Location = new System.Drawing.Point(9, 74);
			this.buttonMapHeightDec.Name = "buttonMapHeightDec";
			this.buttonMapHeightDec.Size = new System.Drawing.Size(23, 23);
			this.buttonMapHeightDec.TabIndex = 13;
			this.buttonMapHeightDec.Text = "-";
			this.buttonMapHeightDec.UseVisualStyleBackColor = true;
			this.buttonMapHeightDec.Click += new System.EventHandler(this.buttonMapHeightDec_Click);
			// 
			// buttonMapWidthInc
			// 
			this.buttonMapWidthInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonMapWidthInc.Location = new System.Drawing.Point(90, 32);
			this.buttonMapWidthInc.Name = "buttonMapWidthInc";
			this.buttonMapWidthInc.Size = new System.Drawing.Size(23, 23);
			this.buttonMapWidthInc.TabIndex = 12;
			this.buttonMapWidthInc.Text = "+";
			this.buttonMapWidthInc.UseVisualStyleBackColor = true;
			this.buttonMapWidthInc.Click += new System.EventHandler(this.buttonMapWidthInc_Click);
			// 
			// buttonMapWidthDec
			// 
			this.buttonMapWidthDec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonMapWidthDec.Location = new System.Drawing.Point(9, 32);
			this.buttonMapWidthDec.Name = "buttonMapWidthDec";
			this.buttonMapWidthDec.Size = new System.Drawing.Size(23, 23);
			this.buttonMapWidthDec.TabIndex = 11;
			this.buttonMapWidthDec.Text = "-";
			this.buttonMapWidthDec.UseVisualStyleBackColor = true;
			this.buttonMapWidthDec.Click += new System.EventHandler(this.buttonMapWidthDec_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.comboBoxLon);
			this.groupBox1.Controls.Add(this.comboBoxLat);
			this.groupBox1.Controls.Add(this.comboBoxZoom);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBoxLat);
			this.groupBox1.Controls.Add(this.textBoxLon);
			this.groupBox1.Location = new System.Drawing.Point(885, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(125, 159);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Карта";
			// 
			// comboBoxLon
			// 
			this.comboBoxLon.FormattingEnabled = true;
			this.comboBoxLon.Location = new System.Drawing.Point(82, 78);
			this.comboBoxLon.Name = "comboBoxLon";
			this.comboBoxLon.Size = new System.Drawing.Size(35, 21);
			this.comboBoxLon.TabIndex = 18;
			// 
			// comboBoxLat
			// 
			this.comboBoxLat.FormattingEnabled = true;
			this.comboBoxLat.Location = new System.Drawing.Point(82, 36);
			this.comboBoxLat.Name = "comboBoxLat";
			this.comboBoxLat.Size = new System.Drawing.Size(35, 21);
			this.comboBoxLat.TabIndex = 17;
			// 
			// comboBoxZoom
			// 
			this.comboBoxZoom.FormattingEnabled = true;
			this.comboBoxZoom.Location = new System.Drawing.Point(9, 119);
			this.comboBoxZoom.Name = "comboBoxZoom";
			this.comboBoxZoom.Size = new System.Drawing.Size(73, 21);
			this.comboBoxZoom.TabIndex = 16;
			this.comboBoxZoom.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 103);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Слой";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Долгота";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Широта";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.buttonDownload);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.buttonMapHeightInc);
			this.groupBox2.Controls.Add(this.textBoxMapHeight);
			this.groupBox2.Controls.Add(this.buttonMapHeightDec);
			this.groupBox2.Controls.Add(this.textBoxMapWidth);
			this.groupBox2.Controls.Add(this.buttonMapWidthInc);
			this.groupBox2.Controls.Add(this.buttonMapWidthDec);
			this.groupBox2.Location = new System.Drawing.Point(885, 177);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(125, 150);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Изображение";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 58);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "Высота";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 15;
			this.label4.Text = "Ширина";
			// 
			// buttonSaveMap
			// 
			this.buttonSaveMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSaveMap.Enabled = false;
			this.buttonSaveMap.Location = new System.Drawing.Point(913, 333);
			this.buttonSaveMap.Name = "buttonSaveMap";
			this.buttonSaveMap.Size = new System.Drawing.Size(75, 23);
			this.buttonSaveMap.TabIndex = 6;
			this.buttonSaveMap.Text = "Сохранить карту";
			this.buttonSaveMap.UseVisualStyleBackColor = true;
			this.buttonSaveMap.Click += new System.EventHandler(this.buttonSaveMap_Click);
			// 
			// buttonAbout
			// 
			this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAbout.Location = new System.Drawing.Point(913, 362);
			this.buttonAbout.Name = "buttonAbout";
			this.buttonAbout.Size = new System.Drawing.Size(75, 23);
			this.buttonAbout.TabIndex = 16;
			this.buttonAbout.Text = "Автора!";
			this.buttonAbout.UseVisualStyleBackColor = true;
			this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
			// 
			// labelMapSize
			// 
			this.labelMapSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelMapSize.AutoSize = true;
			this.labelMapSize.Location = new System.Drawing.Point(882, 532);
			this.labelMapSize.Name = "labelMapSize";
			this.labelMapSize.Size = new System.Drawing.Size(108, 13);
			this.labelMapSize.TabIndex = 17;
			this.labelMapSize.Text = "Размеры карты (м):";
			// 
			// textBoxTopGps
			// 
			this.textBoxTopGps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTopGps.Location = new System.Drawing.Point(916, 401);
			this.textBoxTopGps.Name = "textBoxTopGps";
			this.textBoxTopGps.ReadOnly = true;
			this.textBoxTopGps.Size = new System.Drawing.Size(57, 20);
			this.textBoxTopGps.TabIndex = 18;
			// 
			// textBoxLeftGps
			// 
			this.textBoxLeftGps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLeftGps.Location = new System.Drawing.Point(885, 427);
			this.textBoxLeftGps.Name = "textBoxLeftGps";
			this.textBoxLeftGps.ReadOnly = true;
			this.textBoxLeftGps.Size = new System.Drawing.Size(57, 20);
			this.textBoxLeftGps.TabIndex = 19;
			// 
			// textBoxRightGps
			// 
			this.textBoxRightGps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxRightGps.Location = new System.Drawing.Point(953, 427);
			this.textBoxRightGps.Name = "textBoxRightGps";
			this.textBoxRightGps.ReadOnly = true;
			this.textBoxRightGps.Size = new System.Drawing.Size(57, 20);
			this.textBoxRightGps.TabIndex = 20;
			// 
			// textBoxBottomGps
			// 
			this.textBoxBottomGps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxBottomGps.Location = new System.Drawing.Point(916, 453);
			this.textBoxBottomGps.Name = "textBoxBottomGps";
			this.textBoxBottomGps.ReadOnly = true;
			this.textBoxBottomGps.Size = new System.Drawing.Size(57, 20);
			this.textBoxBottomGps.TabIndex = 21;
			// 
			// labelTilesRect
			// 
			this.labelTilesRect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTilesRect.AutoSize = true;
			this.labelTilesRect.Location = new System.Drawing.Point(882, 572);
			this.labelTilesRect.Name = "labelTilesRect";
			this.labelTilesRect.Size = new System.Drawing.Size(47, 13);
			this.labelTilesRect.TabIndex = 22;
			this.labelTilesRect.Text = "Плитки:";
			// 
			// labelMetPerPix
			// 
			this.labelMetPerPix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelMetPerPix.AutoSize = true;
			this.labelMetPerPix.Location = new System.Drawing.Point(882, 497);
			this.labelMetPerPix.Name = "labelMetPerPix";
			this.labelMetPerPix.Size = new System.Drawing.Size(102, 13);
			this.labelMetPerPix.TabIndex = 23;
			this.labelMetPerPix.Text = "Метров на пиксел:";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapCenteroolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
			// 
			// mapCenteroolStripMenuItem
			// 
			this.mapCenteroolStripMenuItem.Name = "mapCenteroolStripMenuItem";
			this.mapCenteroolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.mapCenteroolStripMenuItem.Text = "Центр карты";
			this.mapCenteroolStripMenuItem.Click += new System.EventHandler(this.mapCenteroolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1022, 668);
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.Controls.Add(this.labelMetPerPix);
			this.Controls.Add(this.labelTilesRect);
			this.Controls.Add(this.textBoxBottomGps);
			this.Controls.Add(this.textBoxRightGps);
			this.Controls.Add(this.textBoxLeftGps);
			this.Controls.Add(this.textBoxTopGps);
			this.Controls.Add(this.labelMapSize);
			this.Controls.Add(this.buttonAbout);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.buttonSaveMap);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.Text = "Orbis Terrarum";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Move += new System.EventHandler(this.btn_redraw_Click);
			this.Resize += new System.EventHandler(this.btn_redraw_Click);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox textBoxLat;
        private System.Windows.Forms.TextBox textBoxLon;
        private System.Windows.Forms.TextBox textBoxMapWidth;
        private System.Windows.Forms.TextBox textBoxMapHeight;
        private System.Windows.Forms.Button buttonMapWidthInc;
        private System.Windows.Forms.Button buttonMapWidthDec;
        private System.Windows.Forms.Button buttonMapHeightDec;
        private System.Windows.Forms.Button buttonMapHeightInc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSaveMap;
        private System.Windows.Forms.ComboBox comboBoxZoom;
		private System.Windows.Forms.Button buttonAbout;
		private System.Windows.Forms.ComboBox comboBoxLat;
		private System.Windows.Forms.ComboBox comboBoxLon;
		private System.Windows.Forms.Label labelMapSize;
		private System.Windows.Forms.TextBox textBoxTopGps;
		private System.Windows.Forms.TextBox textBoxLeftGps;
		private System.Windows.Forms.TextBox textBoxRightGps;
		private System.Windows.Forms.TextBox textBoxBottomGps;
		private System.Windows.Forms.Label labelTilesRect;
		private System.Windows.Forms.Label labelMetPerPix;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mapCenteroolStripMenuItem;
    }
}

