using Microsoft.Xna.Framework;

namespace F2J2A.CommonSimulator.Core
{
	public class TickCounter
	{
		float _currentTimeInMs;

		public TickCounter ()
		{
			ResetTicksCount ();
		}

		public bool IsNextTick(float msNeededBeforeNextTick, GameTime gameTime) 
		{
			_currentTimeInMs += gameTime.ElapsedGameTime.Milliseconds;

			if (_currentTimeInMs >= msNeededBeforeNextTick)
			{
				ResetTicksCount ();
				return true;
			}

			return false;
		}

		private void ResetTicksCount()
		{
			_currentTimeInMs = 0.0f;
		}
	}
}

