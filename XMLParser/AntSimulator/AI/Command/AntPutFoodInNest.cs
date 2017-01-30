using System;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;

namespace F2J2A.AntSimulator.AI.Command
{
    public class AntPutFoodInNest : ICommand
    {
        private AntUnit _unit;
        private NestUnit _nest;

        private FoodUnit _oldFood;

        public AntPutFoodInNest(AntUnit unit, NestUnit nest)
        {
            _unit = unit;
            _nest = nest;
            _oldFood = unit.TransportedFood;
        }

        public void Execute()
        {
            _unit.TransportedFood = null;
            _nest.FoodInsideNest++;

            Console.WriteLine("Food was put inside a nest. Nest has " + _nest.FoodInsideNest);
        }

        public void Undo()
        {
            _unit.TransportedFood = _oldFood;
            _nest.FoodInsideNest--;
        }
    }
}