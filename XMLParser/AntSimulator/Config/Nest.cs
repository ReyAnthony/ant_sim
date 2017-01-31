using System;
using System.Xml.Serialization;
using F2J2A.CommonSimulator.XML;

namespace F2J2A.AntSimulator.Config
{
	[Serializable()]
	public class Nest:ItemWithPosition
	{
	    [XmlAttribute("storage-max")]
	    public int StorageMax
	    {
	        get;
	        set;
	    }
	}
}