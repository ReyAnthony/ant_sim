using System;
using System.Xml.Serialization;

namespace XMLParser
{
	[Serializable()]
	public class ItemWithPosition
	{
		[XmlAttribute("posx")]
		public int PosX
		{
			get;
			set;
		}

		[XmlAttribute("posy")]
		public int PosY
		{
			get;
			set;
		}

		public ItemWithPosition()
		{
		}
	}
}
