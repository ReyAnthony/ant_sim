using System;
using System.Collections.Generic;
using F2J2A.AntSimulator.AI.Command;
using F2J2A.AntSimulator.Config;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;
using F2J2A.CommonSimulator.Core.AI.Commands;

namespace F2J2A.AntSimulator.AI
{
    public class NestAI : CommonSimulator.Core.AI.AI
    {
        private readonly AntGameConfig _antGameConfig;

        private readonly List<NestUnit> _nestUnits;
        private readonly List<AntUnit> _antUnits;
        private readonly List<QueenUnit> _queenUnits;

        private int _numberOfTurnsSinceLastSpawn;

        public NestAI(AntGameConfig config, List<NestUnit> nests, List<AntUnit> ants, List<QueenUnit> queens)
        {
            _antGameConfig = config;
            _nestUnits = nests;
            _antUnits = ants;
            _queenUnits = queens;
        }

        #region AI implementation

        public ICommand GetNextAction ()
        {
            var compositeCommand = new CompositeCommand();

            if (_antUnits.Count < _antGameConfig.Ant.MaxQuantity
                && _numberOfTurnsSinceLastSpawn > _antGameConfig.Ant.SpawnRate)
            {
                _numberOfTurnsSinceLastSpawn = 0;
                var nest = _nestUnits[new Random().Next(_nestUnits.Count)];

                compositeCommand.Add(new AntSpawner(_antGameConfig, nest, _antUnits));
            }

            foreach(var nest in _nestUnits)
            {
                if (!nest.ShouldItCreateAQueen()) continue;

                //spawn a new queen
                compositeCommand.Add(new AntResetNestFoodCount(nest));
                compositeCommand.Add(new AntSpawnQueen(_antGameConfig, _nestUnits, nest, _queenUnits));
            }

            _numberOfTurnsSinceLastSpawn++;
            return compositeCommand;
        }

        #endregion
    }
}

