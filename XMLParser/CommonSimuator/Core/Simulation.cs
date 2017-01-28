using System;

namespace F2J2A.Core
{
	public interface Simulation 
	{
		void OnStart();
		void OnEnd();

		void NextTick();
		void Draw();

		int TimeBeetwenTicksInMs();
	}
}


