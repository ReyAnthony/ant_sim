using System;
using System.Xml.Serialization;

namespace F2J2A.AntSimulator.Config
{
	[Serializable()]
	public class Food
	{

		[XmlAttribute("MaxQuantity")]
		public int MaxQuantity
		{
			get;
			set;
		}

		[XmlAttribute("SpawnRate")]
		public int SpawnRate
		{
			get;
			set;
		}
	}
}