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
        private int _foodBeforeNextQueen;

        public NestUnit(int x, int y, int foodBeforeNextQueen) : base(x, y, 0)
        {
            Texture2D = Simulator.Instance.Textures["nest"];
            _foodBeforeNextQueen = foodBeforeNextQueen;
        }

        public bool ShouldItCreateAQueen()
        {
            return FoodInsideNest > _foodBeforeNextQueen;
        }

        public override void Draw(GameTime gameTime)
            =>  Simulator.Instance.SpriteBatch.Draw(Texture2D, new Vector2(X * 32, Y * 32));

    }
}

