using System;
using Microsoft.Xna.Framework;

namespace F2J2A.CommonSimulator.Core
{
    public class EmptySimulation : ISimulation
    {
        public void Draw(GameTime gameTime)
        {

        }

        public int DrawOrder { get; }
        public bool Visible { get; }
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public void NextTick()
        {

        }

        public int TimeBeetwenTicksInMs { get { return 1; } }
        public void TogglePause()
        {

        }

        public void UndoLastAction()
        {

        }
    }
}