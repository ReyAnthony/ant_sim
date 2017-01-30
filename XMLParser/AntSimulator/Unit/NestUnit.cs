using System;
using F2J2A.CommonSimulator.Core;
using F2J2A.CommonSimulator.Pathfind;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F2J2A.AntSimulator.Unit
{
    public class NestUnit : Node
    {
        public int FoodInsideNest { get; set; }

        public NestUnit(int Abs, int Ord) : base(Abs, Ord, 0)
        {
            Texture2D = Simulator.Instance.Textures["nest"];
        }

        public override void Draw(GameTime gameTime)
            =>  Simulator.Instance.SpriteBatch.Draw(Texture2D, new Vector2(X * 32, Y * 32));

    }
}

