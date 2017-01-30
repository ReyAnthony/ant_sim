using System;
using System.Collections.Generic;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;

namespace F2J2A.AntSimulator.AI.Command
{
	public class AntGrabStuff : ICommand
	{
	    private AntUnit _antUnit;
	    private FoodUnit _foodUnit;
	    private List<FoodUnit> _food;

	    public AntGrabStuff(AntUnit ant, FoodUnit grabbed, List<FoodUnit> food)
	    {
	        _antUnit = ant;
	        _foodUnit = grabbed;
	        _food = food;
	    }

	    public void Execute()
	    {
	        _antUnit.TransportedFood = _foodUnit;
	        _food.Remove(_foodUnit);

	        Console.WriteLine("An ant has grabbed some food");
	    }

	    public void Undo()
	    {
	        _antUnit.TransportedFood = null;
	        _food.Add(_foodUnit);
	    }
	}
}

