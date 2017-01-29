using System;
using System.Xml.Serialization;

namespace XMLParser
{
	[Serializable()]
	public class Map
	{
		[XmlAttribute]
		public int Width
		{
			get;
			set;
		}

		[XmlAttribute]
		public int Height
		{
			get;
			set;
		}
	}
}