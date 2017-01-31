using System;
using System.Xml.Serialization;

namespace F2J2A.CommonSimulator.XML
{
	[Serializable()]
	public class GameConfig
	{
		[XmlElement("Map")]
		public Map Map
		{
			get;
			set;
		}

	    [XmlAttribute("Speed")]
	    public int Speed { get; set; }

		public GameConfig()
		{
		}
	}
}
