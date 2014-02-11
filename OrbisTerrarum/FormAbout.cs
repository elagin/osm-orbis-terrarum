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
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace orbis_terrarum
{
	public partial class FormAbout : Form
	{
		[DllImport("shell32.dll")]
		public static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation,
			string lpFile, string lpParameters, string lpDirectory, int nShowCmd); 
		public FormAbout()
		{
			InitializeComponent();

			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

			//this.Text = String.Format("Orbis Terrarum v.{0}", fvi.FileVersion);

			string about = "'Orbis Terrarum' бесплатное и свободное приложение для использования карт из проекта OpenStreetMap в приложении OziExplorer." + Environment.NewLine + "Распространяется на основе лицензии GPL v2.0 по принципу 'как есть'." + Environment.NewLine + 
				 " Автор не несёт НИКАКОЙ ответственности за любые действия пользователя использующего программу, вся ответственность за использование программой целиком и полностью ложиться на пользователя." +
" Автор не несёт ответственности за любые аппаратные и/или программные ошибки возникающие при работе программы." +
" Автор не несёт ответственности за не совпадения ожиданиям пользователя и функционалом программы.";
			textBox1.Text = about;
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void linkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ShellExecute(IntPtr.Zero, "open", "mailto:elagin.pasha@gmail.com?subject=Orbis%20Terrarum%20feedback&body=Здравствуйте.", "", "", 4 /* sw_shownoactivate */);
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://github.com/elagin/orbis-terrarum");
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://sourceforge.net/projects/osm-orbis-terrarum");
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.gnu.org/licenses");
		}
	}
}
