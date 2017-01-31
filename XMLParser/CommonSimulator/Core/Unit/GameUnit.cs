using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F2J2A.CommonSimulator.Core.Unit
{
    public abstract class GameUnit : IDrawable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Texture2D Texture2D { get; set; }

        public GameUnit()
        {
            X = 0;
            Y = 0;
            Texture2D = null;
        }

        public GameUnit(int x,int y)
        {
            X = x;
            Y = y;
        }

        public abstract void Draw(GameTime gameTime);


        public int DrawOrder { get; }
        public bool Visible { get; }
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
    }
}