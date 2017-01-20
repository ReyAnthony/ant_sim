using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XMLParser
{
	[Serializable()]
	[System.Xml.Serialization.XmlRoot("AntGame")]
	public class AntGame: Game
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


		public AntGame()
		{
		}
	}
}
