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
using System.Linq;
using System.Text;
using System.Drawing;

namespace orbis_terrarum
{
	class Tools
	{
		// http://wiki.openstreetmap.org/wiki/Slippy_map_tilenames
		/// <summary>
		/// Преобразование географических координат в индексы плитки.</summary>
		public static Point worldToTilePos(double lon, double lat, int zoom)
		{
			Point p = new Point();
			p.X = (int)((lon + 180.0) / 360.0 * (1 << zoom));
			p.Y = (int)((1.0 - Math.Log(Math.Tan(lat * Math.PI / 180.0) +
				1.0 / Math.Cos(lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << zoom));

			return p;
		}

		/// <summary>
		/// Преобразование индексов плитки в географические координаты.</summary>
		public static PointF tileToWorldPos(PointF tile, int zoom)
		{
			PointF p = new Point();
			double n = Math.PI - ((2.0 * Math.PI * tile.Y) / Math.Pow(2.0, zoom));

			p.X = (float)((tile.X / Math.Pow(2.0, zoom) * 360.0) - 180.0);
			p.Y = (float)(180.0 / Math.PI * Math.Atan(Math.Sinh(n)));

			return p;
		}

		/// <summary>
		/// Преобразование индексов плитки в географические координаты.</summary>
		public static PointF tileToWorldPos(double tileX, double tileY, int zoom)
		{
			PointF p = new Point();
			double n = Math.PI - ((2.0 * Math.PI * tileY) / Math.Pow(2.0, zoom));

			p.X = (float)((tileX / Math.Pow(2.0, zoom) * 360.0) - 180.0);
			p.Y = (float)(180.0 / Math.PI * Math.Atan(Math.Sinh(n)));

			return p;
		}

		/// <summary>
		/// Переводим доли градуса в минуты и десятичные доли минуты.</summary>
		//http://www.geocaching.su/?pn=35
		public static float grad_to_min(float val)
		{
			int i = (int)val;
			float fract = val - i;
			float res = fract * 60;
			return res;
		}

		/// <summary>
		/// Расчет расстояния между двумя географическими координатами.</summary>
		// http://gis-lab.info/qa/great-circles.html
		public static double calcDist(double llat1, double llong1, double llat2, double llong2)
		{
			//rad - радиус сферы (Земли)
			int rad = 6372795;
			//в радианах
 			double lat1 = llat1 * Math.PI/180;
 			double lat2 = llat2 * Math.PI/180;
 			double long1 = llong1 * Math.PI/180;
 			double long2 = llong2 * Math.PI/180;
 
			//косинусы и синусы широт и разницы долгот
 			double cl1 = Math.Cos(lat1);
 			double cl2 = Math.Cos(lat2);
 			double sl1 = Math.Sin(lat1);
 			double sl2 = Math.Sin(lat2);
 			double delta = long2 - long1;
 			double cdelta = Math.Cos(delta);
 			double sdelta = Math.Sin(delta);
 
			//вычисления длины большого круга
 			double y = Math.Sqrt(Math.Pow(cl2 * sdelta, 2) + Math.Pow(cl1 * sl2 - sl1 * cl2 * cdelta, 2));
			double  x = sl1 * sl2 + cl1 * cl2 * cdelta;
			double  ad = Math.Atan2(y, x);
			double  dist = ad * rad;
 			return dist;
		}
	}
}
