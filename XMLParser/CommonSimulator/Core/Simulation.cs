using Microsoft.Xna.Framework;

namespace F2J2A.CommonSimulator.Core
{
	public interface Simulation : IDrawable
	{
	    void NextTick();
		int TimeBeetwenTicksInMs { get; }
	}
}


