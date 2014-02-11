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

namespace orbis_terrarum
{
	public partial class FormError : Form
	{
		public FormError()
		{
			InitializeComponent();
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void buttonSend_Click(object sender, EventArgs e)
		{

			System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
			message.To.Add("elagin.pasha@gmail.com");
			message.Subject = "get osm error";
			message.From = new System.Net.Mail.MailAddress("From@online.microsoft.com");
			message.Body = "This is the message body";
			System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
			try
			{
				smtp.Send(message);
				const string caption = "Ура!";
				var result = MessageBox.Show("Сообщение успешно отправлено, спасибо за сотрудничество.", caption,
											 MessageBoxButtons.OK,
											 MessageBoxIcon.Information);
			 
			}
 
			catch (Exception ex)
			{
				int a = 0;
			}

		}
	}
}
