using System;
using System.Xml.Serialization;

namespace XMLParser
{
	[Serializable()]
	public class Nest:ItemWithPosition
	{
		[XmlAttribute("MaxStorage")]
		public int maxStorage
		{
			get;
			set;
		}
	}
}