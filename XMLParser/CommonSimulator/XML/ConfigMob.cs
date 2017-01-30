using System;
using System.Xml.Serialization;

namespace F2J2A.CommonSimulator.XML
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