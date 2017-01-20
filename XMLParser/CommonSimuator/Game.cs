using System;
using System.Xml.Serialization;

namespace XMLParser
{
	[Serializable()]
	public class Game
	{
		[XmlElement("Map")]
		public Map Map
		{
			get;
			set;
		}

		public Game()
		{
		}
	}
}
