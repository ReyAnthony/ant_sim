using System;
using Microsoft.Xna.Framework;

namespace F2J2A.Core
{
	public class TickCounter
	{
		float currentTimeInMs;

		public TickCounter ()
		{
			ResetTicksCount ();
		}

		public bool IsNextTick(float msNeededBeforeNextTick, GameTime gameTime) 
		{
			currentTimeInMs += gameTime.ElapsedGameTime.Milliseconds;

			if (currentTimeInMs >= msNeededBeforeNextTick) 
			{
				ResetTicksCount ();
				return true;
			}

			return false;
		}

		private void ResetTicksCount()
		{
			currentTimeInMs = 0.0f;
		}
	}
}

