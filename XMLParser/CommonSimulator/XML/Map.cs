using System;
using System.Xml.Serialization;

namespace F2J2A.CommonSimulator.XML
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