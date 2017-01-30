using System;
using System.Xml;
using F2J2A.CommonSimulator.Core.AI;
using F2J2A.CommonSimulator.Pathfind;

namespace F2J2A.AntSimulator.AI.Command
{
    public class AntDig : ICommand
    {
        private readonly int _x;
        private readonly int _y;
        private readonly Node _digged;

        private int _diggedOldCost;

        public AntDig(Node digged)
        {
            _digged = digged;
        }

        public void Execute()
        {
            Console.WriteLine("Diggin at : " + _digged.X + " , " + _digged.Y);
            _diggedOldCost = _digged.Cost;
            _digged.Cost = 1;
        }

        public void Undo()
        {
            _digged.Cost = _diggedOldCost;
        }
    }
}