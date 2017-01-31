 using System;
using System.Xml.Serialization;
using F2J2A.CommonSimulator.XML;

namespace F2J2A.AntSimulator.Config
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