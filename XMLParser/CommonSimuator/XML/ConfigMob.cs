using System;
using System.Xml.Serialization;

namespace XMLParser
{
	[Serializable()]
	public class ConfigMob
	{
		[XmlAttribute("Quantity")]
		public int Quantity
		{
			get;
			set;
		}

		[XmlAttribute("Health")]
		public int Health
		{
			get;
			set;
		}
	}
}