using System;
using F2J2A.CommonSimulator.Core.Unit;
using F2J2A.CommonSimulator.Pathfind;
using Microsoft.Xna.Framework;

namespace F2J2A.CommonSimulator.Core.AI.Commands
{
	public class MoveTo<T> : ICommand where T : GameUnit
	{
	    private readonly T _unitToMove;
	    private Vector2 _position;
	    private Vector2 _oldPosition;

		public MoveTo (int x, int y, T unit)
		{

		    _position = new Vector2(x , y);
		    _oldPosition = new Vector2(unit.X, unit.Y);
		    _unitToMove = unit;
		}

		#region Command implementation

		public void Execute ()
		{
		    Console.WriteLine("Moving a unit of type "
		                      + typeof(T) + " at :  "
		                      + _unitToMove.X + "  : " + _unitToMove.Y);

		    _unitToMove.X = (int) _position.X;
		    _unitToMove.Y = (int) _position.Y;
		}

		public void Undo ()
		{
		    _unitToMove.X = (int) _oldPosition.X;
		    _unitToMove.Y = (int) _oldPosition.Y;
		}

		#endregion
	}
}

