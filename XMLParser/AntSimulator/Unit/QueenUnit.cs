using System;
using F2J2A.CommonSimulator.Core;
using Microsoft.Xna.Framework;

namespace F2J2A.AntSimulator.Unit
{
    public class QueenUnit : AntUnit
    {
        public Vector2 Destination { get; set; }

        public QueenUnit(int x, int y, Vector2 destination) : base(x, y, null, Int32.MaxValue)
        {
            Texture2D = Simulator.Instance.Textures["antqueen"];
            Destination = destination;
        }

        public override void Draw(GameTime gameTime)
        {
            Simulator.Instance.SpriteBatch.Draw(Texture2D, new Vector2(X * 32, Y * 32));
        }
    }
}