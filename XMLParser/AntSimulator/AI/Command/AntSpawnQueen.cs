using System;
using System.Collections.Generic;
using System.Linq;
using F2J2A.AntSimulator.Config;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;
using F2J2A.CommonSimulator.Pathfind;
using Microsoft.Xna.Framework;

namespace F2J2A.AntSimulator.AI.Command
{
    public class AntSpawnQueen : ICommand
    {
        private readonly AntGameConfig _config;
        private readonly Graph _graph;
        private readonly List<NestUnit> _nests;
        private readonly NestUnit _nest;
        private readonly List<QueenUnit> _queenUnits;

        private QueenUnit _newQueen;


        public AntSpawnQueen(AntGameConfig config, Graph graph, List<NestUnit> nests, NestUnit nest, List<QueenUnit> queenUnits)
        {
            _config = config;
            _graph = graph;
            _nests = nests;
            _nest = nest;
            _queenUnits = queenUnits;
        }

        public void Execute()
        {
            var ymax = _config.Map.Height;
            var xmax = _config.Map.Width;
            var goal = new Vector2();
            var rnd = new Random();

            do
            {
                goal.X = rnd.Next(0, xmax);
                goal.Y = rnd.Next(1, ymax);

            } while (_nests.FindAll(n => n.X == (int) goal.X && n.Y == (int) goal.Y).Any());

             _newQueen = new QueenUnit(_nest.X, _nest.Y, goal);
            _queenUnits.Add(_newQueen);
            Console.WriteLine("Spawning an queen at " + _newQueen.X + " : " + _newQueen.Y );
        }

        public void Undo()
        {
            _queenUnits.Remove(_newQueen);
        }
    }
}