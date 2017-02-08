using System.Collections.Generic;
using F2J2A.AntSimulator.Unit;
using F2J2A.CommonSimulator.Core.AI;
using Microsoft.Xna.Framework;

namespace F2J2A.AntSimulator.AI.Command
{
    public class AntDropStuff : ICommand
    {
        private AntUnit _antUnit;
        private FoodUnit _foodUnit;
        private List<FoodUnit> _food;

        private Vector2 _oldPos;

        public AntDropStuff(AntUnit ant, List<FoodUnit> food)
        {
            _antUnit = ant;
            _food = food;
        }

        public void Execute()
        {
            if (_antUnit.TransportedFood != null)
            {
                _foodUnit = _antUnit.TransportedFood;
                _oldPos = new Vector2(_foodUnit.X, _foodUnit.Y);
                _foodUnit.X = _antUnit.X;
                _foodUnit.Y = _antUnit.Y;
                _food.Add(_foodUnit);
                _antUnit.TransportedFood = null;

            }


        }

        public void Undo()
        {
            if (_food != null)
            {
                _food.Remove(_foodUnit);
                _antUnit.TransportedFood = _foodUnit;
                _foodUnit.X =  (int) _oldPos.X;
                _foodUnit.Y =  (int) _oldPos.Y;
            }

        }
    }
}