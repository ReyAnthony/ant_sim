using System.Collections.Generic;
using System.Linq;
using F2J2A.AntSimulator.AI.Command;
using F2J2A.AntSimulator.Pathfind;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;
using F2J2A.CommonSimulator.Core.AI.Commands;
using F2J2A.CommonSimulator.Pathfind;

namespace F2J2A.AntSimulator.AI
{
    public class QueenAI : CommonSimulator.Core.AI.AI
    {
        private readonly AntGraph _graph;
        private readonly List<QueenUnit> _queens;
        private readonly List<NestUnit> _nests;

        public QueenAI(AntGraph graph, List<QueenUnit> queens, List<NestUnit> nests)
        {
            _graph = graph;
            _queens = queens;
            _nests = nests;
        }

        public ICommand GetNextAction()
        {
            var compositeCommand = new CompositeCommand();
            foreach (var unit in _queens)
            {
                var goal = unit.Destination;

                var path = _graph.GetShortestPath(
                    _graph.FindNode(unit.X, unit.Y),
                    _graph.FindNode((int) goal.X, (int) goal.Y));

                if (path.Count == 0)
                {
                    compositeCommand.Add(new AntCreateNest(unit, _nests, _queens));
                    break;
                }

                var next = path.First();
                if (next.Cost > Node.DEFAULT_NODE_COST)
                {
                    compositeCommand.Add(new AntDig(next));
                    continue;
                }

                compositeCommand.Add(new MoveTo<QueenUnit>(next.X, next.Y, unit));
            }

            return compositeCommand;
        }
    }
}