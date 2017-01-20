using System;
using System.IO;
using System.Xml.Serialization;

namespace XMLParser
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			AntGame antGame = null;
			string file = "AntGame.xml";
			string path = Path.Combine(Environment.CurrentDirectory, @"xml", file);

			XMLReader XmlReader = new XMLReader();
			antGame = XmlReader.ReadXmlFileWith(path, antGame);
			Console.WriteLine(antGame.Map.Height);
			Console.WriteLine(antGame.Nests[0].maxStorage);
			Console.WriteLine(antGame.Food.SpawnRate);
			Console.WriteLine(antGame.Ant.Health);
			Console.WriteLine(antGame.Ant.SpawnRate);
		}
	}
}