using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace F2J2A.Core
{
	public interface Simulation : IDrawable
	{
	    void NextTick();
		int TimeBeetwenTicksInMs();
	}
}


