using System;
using F2J2A.Core;
using F2J2A.Pathfind;
using XMLParser;
using System.IO;

namespace F2J2A.Core
{
	public class AntSimulation : Simulation
	{
		AntGame antGame;

		AI ai;
		Graph graph;

		public AntSimulation ()
		{
			OnStart ();
		}

		#region Simulation implementation
		public void OnStart ()
		{
			//load files and stuff

			ai = new AntAI ();

			string file = "AntGame.xml";
			string path = Path.Combine(Environment.CurrentDirectory, @"xml", file);

			XMLReader XmlReader = new XMLReader();
			antGame = XmlReader.ReadXmlFileWith(path, antGame);

			Graph graph = new Graph (antGame.Map.Width, antGame.Map.Height);

		}

		public void OnEnd ()
		{
			//do something
		}

		public void NextTick ()
		{
			//All the logic is here
			Console.WriteLine("I should be doing stuff");

			var action = ai.getNextAction ();
			if (action != null)
				action.Execute ();
		}

		public void Draw ()
		{
			//Draw all stuff 
		}

		public int TimeBeetwenTicksInMs()
		{
			return 1000;
		}
		#endregion

	}
}

