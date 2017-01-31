using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
	    private readonly AntGameConfig _antGameConfig;

	    private CommonSimulator.Core.AI.AI _antAi;
	    private CommonSimulator.Core.AI.AI _nestsAi;
	    private CommonSimulator.Core.AI.AI _foodAi;
	    private CommonSimulator.Core.AI.AI _queenAI;

	    private bool _paused;

	    private List<AntUnit> _ants;
	    private List<QueenUnit> _queens;
	    private List<NestUnit> _nests;
	    private List<FoodUnit> _food;

	    private List<ICommand> _commands;

	    private GraphDrawer _graphDrawer;

	    public AntSimulation()
	    {
	        _ants = new List<AntUnit>();
	        _nests = new List<NestUnit>();
	        _food = new List<FoodUnit>();
	        _queens = new List<QueenUnit>();
	        _commands = new List<ICommand>();

	        const string file = "AntGameConfig.xml";
	        var path = Path.Combine(Environment.CurrentDirectory, @"", file);

	        var xmlReader = new XMLReader();
	        _antGameConfig = xmlReader.ReadXmlFileWith(path, _antGameConfig);

	        _antGameConfig.Nests.ForEach(n => _nests.Add(new NestUnit(n.PosX, n.PosY, n.StorageMax)));

	        var graph = new AntGraph (_antGameConfig, _antGameConfig.Map.Width, _antGameConfig.Map.Height);
	        _graphDrawer = new GraphDrawer (graph);

	        _antAi = new AntAI (_antGameConfig, graph, _ants, _food, _nests);
	        _nestsAi = new NestAI(_antGameConfig, _nests, _ants, _queens);
	        _foodAi = new FoodAI(_antGameConfig, _food);
	        _queenAI = new QueenAI(graph, _queens, _nests);

	        TimeBeetwenTicksInMs = _antGameConfig.Speed;
	    }

		#region Simulation implementation
		public void NextTick ()
		{
		    if(_paused)
		        return;

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

		    action = _queenAI.GetNextAction ();
		    if (action != null)
		    {
		        _commands.Add(action);
		        action.Execute ();
		    }
		}

	    public int TimeBeetwenTicksInMs { get; set; }
	    public void TogglePause()
	    {
	        _paused = !_paused;
	    }

	    public void UndoLastAction()
	    {
	        if (_commands.Count > 0)
	        {
	           var lastCommand =  _commands.Last();
	            _commands.Remove(lastCommand);
	            lastCommand.Undo();
	        }

	    }

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
	        _queens.ForEach(q => q.Draw(gameTime));
	    }
	    #endregion


	}
}

