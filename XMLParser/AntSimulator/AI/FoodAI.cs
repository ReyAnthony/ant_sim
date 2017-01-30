using System;
using System.Collections.Generic;
using System.Linq;
using F2J2A.AntSimulator.Config;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;
using F2J2A.CommonSimulator.Core.AI.Commands;
using F2J2A.CommonSimulator.Pathfind;

namespace F2J2A.AntSimulator.AI
{
    public class FoodAI : CommonSimulator.Core.AI.AI
    {
        private AntGameConfig _antGameConfig;
        private Graph _graph;
        private List<FoodUnit> _foodUnits;

        private int _numberOfTurnsSinceLastSpawn = 0;

        public FoodAI(AntGameConfig config, Graph graph, List<FoodUnit> food)
        {
            _antGameConfig = config;
            _graph = graph;
            _foodUnits = food;
        }

        #region AI implementation

        public ICommand GetNextAction ()
        {
            if (_foodUnits.Count < _antGameConfig.Food.MaxQuantity
                && _numberOfTurnsSinceLastSpawn > _antGameConfig.Food.SpawnRate)
            {
                _numberOfTurnsSinceLastSpawn = 0;
                var randomXPosition = new Random().Next(0, _antGameConfig.Map.Width);

                var food =
                    from f in _foodUnits
                    where f.X == randomXPosition
                    select f;

                //this means there is already food here
                if (food.Any())
                    return null;

                return new Spawner<FoodUnit>(randomXPosition, 0, _foodUnits);
            }

            _numberOfTurnsSinceLastSpawn++;
            return null;
        }

        #endregion
    }
}

