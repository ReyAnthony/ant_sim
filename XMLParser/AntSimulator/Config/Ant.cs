using System;
using System.Xml.Serialization;

namespace XMLParser
{
	[Serializable()]
	public class Ant:ConfigMob
	{
		[XmlAttribute("SpawnRate")]
		public int SpawnRate
		{
			get;
			set;
		}

		[XmlAttribute("MaxQuantity")]
		public int MaxQuantity
		{
			get;
			set;
		}
	}
}