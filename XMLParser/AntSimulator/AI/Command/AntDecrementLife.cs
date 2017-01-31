using System;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;

namespace F2J2A.AntSimulator.AI.Command
{
    public class AntDecrementLife : ICommand
    {
        private readonly AntUnit _unit;

        public AntDecrementLife(AntUnit unit)
        {
            _unit = unit;
        }

        public void Execute()
        {
            _unit.Health--;
            Console.WriteLine("Decrementing life of ant at " + _unit.X + " : " + _unit.Y );
        }

        public void Undo()
        {
            _unit.Health++;
        }
    }
}