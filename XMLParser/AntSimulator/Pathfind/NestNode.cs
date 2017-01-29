using System;
using F2J2A.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F2J2A.Pathfind
{
    public class NestNode : Node
    {
        private Texture2D sprite;

        public NestNode(int Abs, int Ord)
        {
            sprite = Simulator.Instance.Textures["nest"];

            this.Abs = Abs;
            this.Ord = Ord;
        }

        public void Draw(GameTime gameTime)
        {
            Simulator.Instance.SpriteBatch.Draw(sprite, new Vector2(Abs * 32, Ord * 32));
        }

        public int DrawOrder { get; }
        public bool Visible { get; }
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public int Abs { get; set; }
        public int Ord { get; set; }
    }
}

