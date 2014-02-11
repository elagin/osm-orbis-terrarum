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
			this.SuspendLayout();
			// 
			// buttonStop
			// 
			this.buttonStop.Location = new System.Drawing.Point(312, 133);
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
			this.labelTotalBytes.Location = new System.Drawing.Point(64, 84);
			this.labelTotalBytes.Name = "labelTotalBytes";
			this.labelTotalBytes.Size = new System.Drawing.Size(84, 13);
			this.labelTotalBytes.TabIndex = 1;
			this.labelTotalBytes.Text = "Получено байт:";
			// 
			// ProgressBar1
			// 
			this.ProgressBar1.Location = new System.Drawing.Point(12, 47);
			this.ProgressBar1.Name = "ProgressBar1";
			this.ProgressBar1.Size = new System.Drawing.Size(675, 23);
			this.ProgressBar1.TabIndex = 2;
			// 
			// labelTilesCnt
			// 
			this.labelTilesCnt.AutoSize = true;
			this.labelTilesCnt.Location = new System.Drawing.Point(288, 84);
			this.labelTilesCnt.Name = "labelTilesCnt";
			this.labelTilesCnt.Size = new System.Drawing.Size(99, 13);
			this.labelTilesCnt.TabIndex = 3;
			this.labelTilesCnt.Text = "Получено плиток: ";
			// 
			// labelTime
			// 
			this.labelTime.AutoSize = true;
			this.labelTime.Location = new System.Drawing.Point(560, 84);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new System.Drawing.Size(46, 13);
			this.labelTime.TabIndex = 4;
			this.labelTime.Text = "Время :";
			// 
			// FormDownload
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(699, 168);
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
    }
}