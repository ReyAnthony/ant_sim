using System;
using System.Collections.Generic;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;

namespace F2J2A.AntSimulator.AI.Command
{
    public class AntCreateNest : ICommand
    {
        private readonly QueenUnit _unit;
        private readonly List<NestUnit> _nests;
        private readonly List<QueenUnit> _queens;

        private NestUnit _newNest;

        public AntCreateNest(QueenUnit unit, List<NestUnit> nests, List<QueenUnit> queens)
        {
            _unit = unit;
            _nests = nests;
            _queens = queens;
        }

        public void Execute()
        {
            _newNest = new NestUnit(_unit.X, _unit.Y);
            _queens.Remove(_unit);

            _nests.Add(_newNest);
            Console.WriteLine("Creating a nest at " + _unit.X + " : " + _unit.Y );
        }

        public void Undo()
        {
            _nests.Remove(_newNest);
            _queens.Add(_unit);
        }
    }
}