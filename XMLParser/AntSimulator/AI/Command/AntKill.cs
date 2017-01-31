using System.Collections.Generic;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;

namespace F2J2A.AntSimulator.AI.Command
{
    public class AntKill : ICommand
    {
        private readonly AntUnit _unit;
        private readonly List<AntUnit> _ants;

        public AntKill(AntUnit unit, List<AntUnit> ants)
        {
            _unit = unit;
            _ants = ants;
        }

        public void Execute()
        {
            _ants.Remove(_unit);
        }

        public void Undo()
        {
            _ants.Add(_unit);
        }
    }
}