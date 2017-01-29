using System;
using System.Collections.Generic;
using System.IO;
using F2J2A.Pathfind;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using XMLParser;

namespace F2J2A.Core
{
	public class AntSimulation : Simulation
	{
		AntGameConfig antGameConfig;

		AI ai;
		Graph graph;
		GraphDrawer graphDrawer;

	    public AntSimulation()
	    {
	        //load files and stuff
	        ai = new AntAI ();

	        string file = "AntGameConfig.xml";
	        string path = Path.Combine(Environment.CurrentDirectory, @"", file);

	        XMLReader XmlReader = new XMLReader();
	        antGameConfig = XmlReader.ReadXmlFileWith(path, antGameConfig);

	        Graph graph = new AntGraph (antGameConfig, antGameConfig.Map.Width, antGameConfig.Map.Height);
	        graphDrawer = new GraphDrawer (graph);
	    }

		#region Simulation implementation
		public void NextTick ()
		{
			//All the logic is here
			var action = ai.getNextAction ();
			if (action != null)
				action.Execute ();
		}

	    public int TimeBeetwenTicksInMs()
		{
			return 1000;
		}

	    public int DrawOrder { get; }
	    public bool Visible { get; }
	    public event EventHandler<EventArgs> DrawOrderChanged;
	    public event EventHandler<EventArgs> VisibleChanged;

	    public void Draw (GameTime gameTime)
	    {
	        graphDrawer.Draw (gameTime);
	    }
	    #endregion


	}
}

