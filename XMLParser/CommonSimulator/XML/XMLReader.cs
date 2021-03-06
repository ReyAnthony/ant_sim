﻿using System;
using System.IO;
using System.Xml.Serialization;

namespace F2J2A.CommonSimulator.XML
{
	public class XMLReader
	{
		public XMLReader()
		{
		}

		public T ReadXmlFileWith<T>(String xml, T game) 
		{ 
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			StreamReader reader = new StreamReader(xml);
			game = (T)serializer.Deserialize(reader);
			reader.Close();
			return game;
		}
	}
}
