using System;
using System.IO;
using System.Xml.Serialization;
using F2J2A.CommonSimulator.Core;

namespace XMLParser
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var game = new Simulator ();
			game.Run ();
		}
	}
}