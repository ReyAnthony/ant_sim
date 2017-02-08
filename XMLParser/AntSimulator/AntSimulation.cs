using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using F2J2A.AntSimulator.AI;
using F2J2A.AntSimulator.AI.Command;
using F2J2A.AntSimulator.Config;
using F2J2A.AntSimulator.Pathfind;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core;
using F2J2A.CommonSimulator.Core.AI;
using F2J2A.CommonSimulator.Pathfind;
using F2J2A.CommonSimulator.XML;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace F2J2A.AntSimulator
{
	public class AntSimulation : ISimulation
	{
	    private readonly AntGameConfig _antGameConfig;

	    private readonly CommonSimulator.Core.AI.AI _antAi;
	    private readonly CommonSimulator.Core.AI.AI _nestsAi;
	    private readonly CommonSimulator.Core.AI.AI _foodAi;
	    private readonly CommonSimulator.Core.AI.AI _queenAI;

	    private bool _paused;

	    private readonly List<AntUnit> _ants;
	    private readonly List<QueenUnit> _queens;
	    private readonly List<NestUnit> _nests;
	    private readonly List<FoodUnit> _food;
	    private readonly List<AntCorpse> _antCorpses;

	    private readonly List<ICommand> _commands;

	    private readonly GraphDrawer _graphDrawer;

	    public AntSimulation()
	    {
	        _ants = new List<AntUnit>();
	        _nests = new List<NestUnit>();
	        _food = new List<FoodUnit>();
	        _antCorpses = new List<AntCorpse>();
	        _queens = new List<QueenUnit>();
	        _commands = new List<ICommand>();


	        const string file = "AntGameConfig.xml";
	        var path = Path.Combine(Environment.CurrentDirectory, @"", file);

	        var xmlReader = new XMLReader();
	        _antGameConfig = xmlReader.ReadXmlFileWith(path, _antGameConfig);

	        _antGameConfig.Nests.ForEach(n => _nests.Add(new NestUnit(n.PosX, n.PosY, n.StorageMax)));

	        var graph = new AntGraph (_antGameConfig, _antGameConfig.Map.Width, _antGameConfig.Map.Height);
	        _graphDrawer = new GraphDrawer (graph);

	        _antAi = new AntAI (_antGameConfig, graph, _ants, _food, _nests, _antCorpses);
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

		    if (Keyboard.GetState().IsKeyDown(Keys.Right))
		        TimeBeetwenTicksInMs = _antGameConfig.Speed / 4;
		    else
		        TimeBeetwenTicksInMs = _antGameConfig.Speed;

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

		    if (_antCorpses.Count > 10)
		    {
		        var clear = new ClearCorpses(_antCorpses);
		        _commands.Add(clear);
		        clear.Execute();

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
	        _antCorpses.ForEach(a => a.Draw(gameTime));
	        _food.ForEach(f => f.Draw(gameTime));
	        _ants.ForEach(a => a.Draw(gameTime));
	        _queens.ForEach(q => q.Draw(gameTime));

	    }
	    #endregion


	}
}

