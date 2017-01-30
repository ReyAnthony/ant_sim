using System;
using System.Collections.Generic;
using F2J2A.AntSimulator.AI.Command;
using F2J2A.AntSimulator.Config;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;
using F2J2A.CommonSimulator.Pathfind;

namespace F2J2A.AntSimulator.AI
{
    public class NestAI : CommonSimulator.Core.AI.AI
    {
        private AntGameConfig _antGameConfig;
        private Graph _graph;

        private readonly List<NestUnit> _nestUnits;
        private readonly List<AntUnit> _antUnits;

        private int _numberOfTurnsSinceLastSpawn = 0;

        public NestAI(AntGameConfig config, Graph graph, List<NestUnit> nests, List<AntUnit> ants)
        {
            _antGameConfig = config;
            _graph = graph;
            _nestUnits = nests;
            _antUnits = ants;
        }

        #region AI implementation

        public ICommand GetNextAction ()
        {
            if (_antUnits.Count < _antGameConfig.Ant.MaxQuantity
                && _numberOfTurnsSinceLastSpawn > _antGameConfig.Ant.SpawnRate)
            {
                _numberOfTurnsSinceLastSpawn = 0;
                var nest = _nestUnits[new Random().Next(_nestUnits.Count)];
                return new AntSpawner(_antGameConfig, nest, _antUnits);
            }

            _numberOfTurnsSinceLastSpawn++;
            return null;
        }

        #endregion
    }
}

