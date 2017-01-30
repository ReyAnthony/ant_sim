using System;
using System.Collections.Generic;
using System.Linq;
using F2J2A.AntSimulator.AI.Command;
using F2J2A.AntSimulator.Config;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;
using F2J2A.CommonSimulator.Core.AI.Commands;
using F2J2A.CommonSimulator.Pathfind;

namespace F2J2A.AntSimulator.AI
{
	public class AntAI : CommonSimulator.Core.AI.AI
	{
	    private AntGameConfig _antGameConfig;
	    private readonly Graph _graph;

	    private readonly List<AntUnit> _ants;
	    private readonly List<FoodUnit> _food;
	    private readonly List<NestUnit> _nests;

	    public AntAI (AntGameConfig config, Graph graph, List<AntUnit> ants, List<FoodUnit> food, List<NestUnit> nests)
		{
		    _antGameConfig = config;
		    _graph = graph;

		    _ants = ants;
		    _food = food;
		    _nests = nests;
		}

	    private void IaForAntLookingForFood(CompositeCommand<AntUnit> compositeCommand)
	    {
	        foreach (AntUnit unit in _ants.FindAll(a => a.TransportedFood == null))
	        {
	            if (_food.Count == 0)
	            {
	                Console.WriteLine("No More food !!!!");
	                break;
	            }

	            var goal = _food.First();

	            var path = _graph.GetShortestPath(
	                _graph.FindNode(unit.X, unit.Y),
	                _graph.FindNode(goal.X, goal.Y));

	            if (path.Count == 0)
	            {
	                var grabbedFood = goal;
                    compositeCommand.Add(new AntGrabStuff(unit, grabbedFood, _food));
	                break;
	            }

	            var next = path.First();
	            if (next.Cost > Node.DEFAULT_NODE_COST)
	            {
	                compositeCommand.Add(new AntDig(next));
	                continue;
	            }

	            compositeCommand.Add(new MoveTo<AntUnit>(next.X, next.Y, unit));
	        }
	    }

	    private void IaForAntRetrievingFood(CompositeCommand<AntUnit> compositeCommand)
	    {

	        foreach (AntUnit unit in _ants.FindAll(a => a.TransportedFood != null))
	        {
	            var goal = unit.BaseNest;

	            var path = _graph.GetShortestPath(
	                _graph.FindNode(unit.X, unit.Y),
	                _graph.FindNode(goal.X, goal.Y));

	            if (path.Count == 0)
	            {
                    compositeCommand.Add(new AntPutFoodInNest(unit, goal));
	                break;
	            }

	            var next = path.First();
	            if (next.Cost > Node.DEFAULT_NODE_COST)
	            {
	                compositeCommand.Add(new AntDig(next));
	                continue;
	            }

	            compositeCommand.Add(new MoveTo<AntUnit>(next.X, next.Y, unit));
	        }
	    }

	    #region AI implementation

		public ICommand GetNextAction ()
		{
		    CompositeCommand<AntUnit> compositeCommand = new CompositeCommand<AntUnit>();

		    IaForAntLookingForFood(compositeCommand);
		    IaForAntRetrievingFood(compositeCommand);

		    return compositeCommand;
		}
	    #endregion
	}
}

