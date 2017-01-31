using Microsoft.Xna.Framework;

namespace F2J2A.CommonSimulator.Core
{
	public interface ISimulation : IDrawable
	{
	    void NextTick();
		int TimeBeetwenTicksInMs { get; }
	    void TogglePause();
	    void UndoLastAction();
	}
}


