using System;
using System.Collections.Generic;
using F2J2A.AntSimulator.Config;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;

namespace F2J2A.AntSimulator.AI.Command
{
    public class AntSpawner : ICommand
    {
        private readonly AntGameConfig _antGameConfig;
        private readonly NestUnit _nestUnit;
        private readonly List<AntUnit> _ants;

        private AntUnit _addedAnt;

        public AntSpawner(AntGameConfig antGameConfig, NestUnit nestUnit, List<AntUnit> ants)
        {
            _antGameConfig = antGameConfig;
            _nestUnit = nestUnit;
            _ants = ants;
        }

        public void Execute()
        {
            _addedAnt = new AntUnit(_nestUnit.X, _nestUnit.Y, _nestUnit, _antGameConfig.Ant.Health);
            _ants.Add(_addedAnt);
            Console.WriteLine("Spawning an ant at " + _addedAnt.X + " : " + _addedAnt.Y );
        }

        public void Undo()
        {
            _ants.Remove(_addedAnt);
        }
    }
}