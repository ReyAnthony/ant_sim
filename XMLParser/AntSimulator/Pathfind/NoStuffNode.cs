using System;
using Microsoft.Xna.Framework;

namespace F2J2A.Pathfind
{
    public class NoStuffNode : Node
    {

        public NoStuffNode(int Abs, int Ord)
        {
            this.Abs = Abs;
            this.Ord = Ord;
        }

        public void Draw(GameTime gameTime)
        {
           //do nothing
        }

        public int DrawOrder { get; }
        public bool Visible { get; }
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public int Abs { get; set; }
        public int Ord { get; set; }
    }
}

