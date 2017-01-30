using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using F2J2A.CommonSimulator.XML;

namespace F2J2A.AntSimulator.Config
{
	[Serializable()]
	[System.Xml.Serialization.XmlRoot("AntGameConfig")]
	public class AntGameConfig: GameConfig
	{
		//[XmlElement("Map")]
		//public Map Map
		//{
		//	get;
		//	set;
		//}

		[XmlArray("Nests")]
		[XmlArrayItem("Nest", typeof(Nest))]
		public List<Nest> Nests
		{
			get;
			set;
		}

		[XmlElement("Food")]
		public Food Food
		{
			get;
			set;
		}

		[XmlElement("Ant")]
		public Ant Ant
		{
			get;
			set;
		}


		public AntGameConfig()
		{
		}
	}
}
