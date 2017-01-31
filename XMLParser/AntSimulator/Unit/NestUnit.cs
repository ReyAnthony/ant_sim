using F2J2A.CommonSimulator.Core;
using F2J2A.CommonSimulator.Core.Unit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F2J2A.AntSimulator.Unit
{
    public class NestUnit : GameUnit
    {
        public int FoodInsideNest { get; set; }
        public int FoodBeforeNextQueen { get; }

        public NestUnit(int x, int y, int foodBeforeNextQueen) : base(x, y)
        {
            Texture2D = Simulator.Instance.Textures["nest"];
            FoodBeforeNextQueen = foodBeforeNextQueen;
        }

        public bool ShouldItCreateAQueen()
        {
            return FoodInsideNest > FoodBeforeNextQueen;
        }

        public override void Draw(GameTime gameTime)
            =>  Simulator.Instance.SpriteBatch.Draw(Texture2D, new Vector2(X * 32, Y * 32));

    }
}

