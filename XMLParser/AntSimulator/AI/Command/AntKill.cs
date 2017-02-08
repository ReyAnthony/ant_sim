using System;
using System.Collections.Generic;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;

namespace F2J2A.AntSimulator.AI.Command
{
    public class AntKill : ICommand
    {
        private readonly AntUnit _unit;
        private readonly List<AntUnit> _ants;
        private readonly List<AntCorpse> _corpses;

        private AntCorpse _corpse;

        public AntKill(AntUnit unit, List<AntUnit> ants, List<AntCorpse> corpses)
        {
            _unit = unit;
            _ants = ants;
            _corpses = corpses;
        }

        public void Execute()
        {
            _corpse = new AntCorpse(_unit.X, _unit.Y);

            _ants.Remove(_unit);

            _corpses.Add(_corpse);

            Console.WriteLine("Killing ant at " + _unit.X + " : " + _unit.Y );
        }

        public void Undo()
        {
            _ants.Add(_unit);
            _corpses.Remove(_corpse);
        }
    }
}