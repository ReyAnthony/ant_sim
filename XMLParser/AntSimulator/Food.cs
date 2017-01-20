using System;
using System.Xml.Serialization;

namespace XMLParser
{
	[Serializable()]
	public class Food
	{
		[XmlAttribute("Quantity")]
		public int Quantity
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

		[XmlAttribute("SpawnRate")]
		public int SpawnRate
		{
			get;
			set;
		}
	}
}