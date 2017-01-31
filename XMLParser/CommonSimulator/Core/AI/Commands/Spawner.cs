using System;
using System.Collections.Generic;
using F2J2A.CommonSimulator.Core.Unit;
using F2J2A.CommonSimulator.Pathfind;

namespace F2J2A.CommonSimulator.Core.AI.Commands
{
    public class Spawner<T> : ICommand where T : GameUnit, new()
    {
        private readonly List<T> _units;
        private readonly T _addedUnit;

        public Spawner (int x, int y, List<T> units)
        {
            _units = units;

            //wow C# !!!!!
            _addedUnit = new T
            {
                X = x,
                Y = y
            };
        }

        #region Command implementation

        public void Execute ()
        {
            Console.WriteLine("Spawning a unit of type "
                              + typeof(T) + " at :  "
                              + _addedUnit.X + "  : " + _addedUnit.Y);
            _units.Add(_addedUnit);
        }

        public void Undo () => _units.Remove(_addedUnit);

        #endregion
    }
}

