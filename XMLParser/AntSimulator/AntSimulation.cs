using System;
using System.Collections.Generic;
using System.IO;
using F2J2A.AntSimulator.AI;
using F2J2A.AntSimulator.Config;
using F2J2A.AntSimulator.Pathfind;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core;
using F2J2A.CommonSimulator.Core.AI;
using F2J2A.CommonSimulator.Pathfind;
using F2J2A.CommonSimulator.XML;
using Microsoft.Xna.Framework;

namespace F2J2A.AntSimulator
{
	public class AntSimulation : Simulation
	{
		AntGameConfig _antGameConfig;

		CommonSimulator.Core.AI.AI _antAi;
	    CommonSimulator.Core.AI.AI _nestsAi;
	    CommonSimulator.Core.AI.AI _foodAi;

	    List<AntUnit> _ants;
	    List<NestUnit> _nests;
	    List<FoodUnit> _food;

	    List<ICommand> _commands;

	    GraphDrawer _graphDrawer;

	    public AntSimulation()
	    {
	        _ants = new List<AntUnit>();
	        _nests = new List<NestUnit>();
	        _food = new List<FoodUnit>();
	        _commands = new List<ICommand>();

	        const string file = "AntGameConfig.xml";
	        var path = Path.Combine(Environment.CurrentDirectory, @"", file);

	        var xmlReader = new XMLReader();
	        _antGameConfig = xmlReader.ReadXmlFileWith(path, _antGameConfig);

	        _antGameConfig.Nests.ForEach(n => _nests.Add(new NestUnit(n.PosX, n.PosY)));

	        var graph = new AntGraph (_antGameConfig, _antGameConfig.Map.Width, _antGameConfig.Map.Height);
	        _graphDrawer = new GraphDrawer (graph);

	        _antAi = new AntAI (_antGameConfig, graph, _ants, _food, _nests);
	        _nestsAi = new NestAI(_antGameConfig, graph, _nests, _ants);
	        _foodAi = new FoodAI(_antGameConfig, graph, _food);
	    }

		#region Simulation implementation
		public void NextTick ()
		{
		    var action = _nestsAi.GetNextAction ();
		    if (action != null)
		    {
		        _commands.Add(action);
		        action.Execute ();
		    }

		    action = _foodAi.GetNextAction ();
		    if (action != null)
		    {
		        _commands.Add(action);
		        action.Execute ();
		    }

		    action = _antAi.GetNextAction ();
		    if (action != null)
		    {
		        _commands.Add(action);
		        action.Execute ();
		    }
		}

	    public int TimeBeetwenTicksInMs => 100;

	    public int DrawOrder { get; }
	    public bool Visible { get; }
	    public event EventHandler<EventArgs> DrawOrderChanged;
	    public event EventHandler<EventArgs> VisibleChanged;

	    public void Draw(GameTime gameTime)
	    {
	        _graphDrawer.Draw (gameTime);
	        _nests.ForEach(n => n.Draw(gameTime));
	        _food.ForEach(f => f.Draw(gameTime));
	        _ants.ForEach(a => a.Draw(gameTime));
	    }
	    #endregion


	}
}

