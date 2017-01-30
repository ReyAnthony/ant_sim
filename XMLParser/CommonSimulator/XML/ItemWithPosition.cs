using System;
using System.Xml.Serialization;

namespace F2J2A.CommonSimulator.XML
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
