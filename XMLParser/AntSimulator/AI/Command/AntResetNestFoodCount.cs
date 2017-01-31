using System;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;

namespace F2J2A.AntSimulator.AI.Command
{
    public class AntResetNestFoodCount : ICommand
    {
        private readonly NestUnit _nest;
        private readonly int _oldValue;

        public AntResetNestFoodCount(NestUnit nest)
        {
            _nest = nest;
            _oldValue = nest.FoodInsideNest;
        }

        public void Execute()
        {
            _nest.FoodInsideNest = 0;
            Console.WriteLine("Reseting nest food at " + _nest.X + " : " + _nest.Y );
        }

        public void Undo()
        {
            _nest.FoodInsideNest = _oldValue;
        }
    }
}