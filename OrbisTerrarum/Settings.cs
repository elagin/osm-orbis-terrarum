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
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

public class MapSize
{
	private int _width;
	private int _height;

	public MapSize()
	{
	}

	public MapSize(int width, int height)
	{
		_width = width;
		_height = height;
	}

	public int Width
	{
		get { return _width; }
		set { _width = value; }
	}

	public int Height
	{
		get { return _height; }
		set { _height = value; }
	}
}

public class GpsPoint
{
	private float _lat;
	private float _lon;

	public GpsPoint()
	{
	}

	public GpsPoint(float lat, float lon)
	{
		_lat = lat;
		_lon = lon;
	}

	public float Lat
	{
		get { return _lat; }
		set { _lat = value; }
	}

	public float Lon
	{
		get { return _lon; }
		set { _lon = value; }
	}
}

public class Settings
{
	private MapSize _mapSize;
	private string _filename;
	private int _zoom;
	private GpsPoint _centralPoint;

	private Point _tileSize;

	public MapSize MapSize
	{
		get { return _mapSize; }
		set { _mapSize = value; }
	}

	public GpsPoint CentralPoint
	{
		get { return _centralPoint; }
		set { _centralPoint = value; }
	}

	public int Zoom
	{
		get { return _zoom; }
		set { _zoom = value; }
	}

	public Settings()
	{
	}

	public Settings(string fileName, Point tileSize)
	{
		try
		{
			_tileSize = tileSize;
			_filename = Assembly.GetExecutingAssembly().Location;// +".config";
			int start_ptr = _filename.LastIndexOf('\\');
			_filename = _filename.Substring(0, start_ptr + 1) + fileName + ".xml";
			SetDefault();
			load();
		}
		catch (Exception ex)
		{
			String logStr = "Settings Exception: " + ex.ToString();
			throw new Exception(logStr);
		}
	}

	public void load()
	{
		try
		{
			if (System.IO.File.Exists(_filename))
			{
				XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
				ns.Add("", "");

				XmlSerializer xmls = new XmlSerializer(typeof(Settings));
				using (FileStream ms = new FileStream(_filename, System.IO.FileMode.OpenOrCreate))
				{
					XmlWriterSettings settings = new XmlWriterSettings();
					using (XmlTextReader reader = new XmlTextReader(ms))
					{
						Settings Clss1 = (Settings)xmls.Deserialize(reader);
						this.CopyFrom(Clss1);
						reader.Close();
					}
				}
			}
		}
		catch (Exception ex)
		{
			string caption = "Произошла ошибка при загрузке файла настроек: " + _filename;
			var result = MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	public void save()
	{
		try
		{
			XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
			ns.Add("", "");
			XmlSerializer xmls = new XmlSerializer(typeof(Settings));
			if (System.IO.File.Exists(_filename))
				System.IO.File.Delete(_filename);

			using (FileStream ms = new FileStream(_filename, System.IO.FileMode.OpenOrCreate))
			{
				XmlWriterSettings settings = new XmlWriterSettings();
				//settings.Encoding = Encoding.GetEncoding(1251)
				settings.Indent = true;
				using (XmlWriter writer = XmlTextWriter.Create(ms, settings))
				{
					xmls.Serialize(writer, this, ns);
					writer.Flush();
					writer.Close();
				}
				ms.Flush();
				ms.Close();
			}
		}
		catch (Exception ex)
		{
			string caption = "Произошла ошибка при сохранении файла настроек: " + _filename;
			var result = MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void SetDefault()
	{
		this._zoom = 15;
		this._centralPoint = new GpsPoint(1,1);
		this._mapSize = new MapSize(_tileSize.X, _tileSize.Y);
	}

	private void CopyFrom(Settings Obj)
	{
		this.Zoom = Obj.Zoom;
		// Нового объекта может не быть в старой версии настроек
		if (Obj.CentralPoint != null)
			this.CentralPoint = Obj.CentralPoint;
		if(Obj.MapSize != null)
			this.MapSize = Obj.MapSize;
	}
}


