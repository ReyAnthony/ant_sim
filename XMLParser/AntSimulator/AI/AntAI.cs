﻿using System;
using System.Collections.Generic;
using System.Linq;
using F2J2A.AntSimulator.AI.Command;
using F2J2A.AntSimulator.Config;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;
using F2J2A.CommonSimulator.Core.AI.Commands;
using F2J2A.CommonSimulator.Pathfind;
using Microsoft.Xna.Framework;

namespace F2J2A.AntSimulator.AI
{
	public class AntAI : CommonSimulator.Core.AI.AI
	{
	    private AntGameConfig _antGameConfig;
	    private readonly Graph _graph;

	    private readonly List<AntUnit> _ants;
	    private readonly List<FoodUnit> _food;
	    private readonly List<NestUnit> _nests;
	    private readonly List<AntCorpse> _corpses;

	    public FoodUnit FindNearest(List<FoodUnit> food, AntUnit player)
	    {
	        Vector2? closest = null;
	        var closestDistance = float.MaxValue;
	        foreach (var f in food) {
	            var position = new Vector2(f.X, f.Y);
	            var distance = Vector2.DistanceSquared(position, new Vector2(player.X, player.Y));
	            if (!closest.HasValue || distance < closestDistance) {
	                closest = position;
	                closestDistance = distance;
	            }
	        }

	        if (closest.HasValue)
	            return food.Find(f => new Vector2(f.X, f.Y) == closest);
	        else
	            return null;
	    }

	    public AntAI (AntGameConfig config, Graph graph, List<AntUnit> ants, List<FoodUnit> food, List<NestUnit> nests, List<AntCorpse> antCorpses)
		{
		    _antGameConfig = config;
		    _graph = graph;

		    _ants = ants;
		    _food = food;
		    _nests = nests;
		    _corpses = antCorpses;
		}

	    private void IaForAntLookingForFood(CompositeCommand compositeCommand)
	    {
	        foreach (var unit in _ants.FindAll(a => a.TransportedFood == null))
	        {
	            if (_food.Count == 0)
	            {
	                break;
	            }

	            var goal = FindNearest(_food, unit);

	            if(goal == null)
	                break;

	            var path = _graph.GetShortestPath(
	                _graph.FindNodeFromPosition(unit.X, unit.Y),
	                _graph.FindNodeFromPosition(goal.X, goal.Y));

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

	    private void IaForAntRetrievingFood(CompositeCommand compositeCommand)
	    {

	        foreach (var unit in _ants.FindAll(a => a.TransportedFood != null))
	        {
	            var goal = unit.BaseNest;

	            var path = _graph.GetShortestPath(
	                _graph.FindNodeFromPosition(unit.X, unit.Y),
	                _graph.FindNodeFromPosition(goal.X, goal.Y));

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

	    private void DecrementLifeOfAntsWithoutFood(CompositeCommand compositeCommand)
	    {
	        foreach (var unit in _ants.FindAll(a => a.TransportedFood == null))
	        {
	            if (unit.Health > 0)
	                compositeCommand.Add(new AntDecrementLife(unit));
	            else
	            {
	                //compositeCommand.Add(new AntDropStuff(unit, _food));
	                compositeCommand.Add(new AntKill(unit, _ants, _corpses));
	            }

	        }
	    }


	    #region AI implementation

		public ICommand GetNextAction ()
		{
		    var compositeCommand = new CompositeCommand();

		    IaForAntLookingForFood(compositeCommand);
		    IaForAntRetrievingFood(compositeCommand);
		    DecrementLifeOfAntsWithoutFood(compositeCommand);

		    return compositeCommand;
		}

	    #endregion
	}
}

