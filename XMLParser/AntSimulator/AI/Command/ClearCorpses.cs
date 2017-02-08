using System.Collections.Generic;
using System.Linq;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;

namespace F2J2A.AntSimulator.AI.Command
{
    public class ClearCorpses : ICommand
    {
        private readonly List<AntCorpse> _corpses;
        private readonly List<AntCorpse> _deletedCorpses;

        public ClearCorpses(List<AntCorpse> corpses)
        {
            _corpses = corpses;
            _deletedCorpses = new List<AntCorpse>();
        }

        public void Execute()
        {
            _deletedCorpses.AddRange(_corpses);
            _corpses.Clear();
        }

        public void Undo()
        {
           _corpses.AddRange(_deletedCorpses);
           _deletedCorpses.Clear();
        }
    }
}