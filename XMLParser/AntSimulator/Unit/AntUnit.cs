using F2J2A.CommonSimulator.Core;
using F2J2A.CommonSimulator.Core.Unit;
using Microsoft.Xna.Framework;

namespace F2J2A.AntSimulator.Unit
{
    public class AntUnit : GameUnit
    {
        public FoodUnit TransportedFood { get; set; }
        public NestUnit BaseNest;
        public int Health;

        public AntUnit()
        {
            Texture2D = Simulator.Instance.Textures["ant"];
        }

        public AntUnit(int x, int y, NestUnit baseNest, int life) : base(x, y)
        {
            Texture2D = Simulator.Instance.Textures["ant"];
            BaseNest = baseNest;
            Health = life;
        }

        public override void Draw(GameTime gameTime)
        {
            if(TransportedFood != null)
                Texture2D = Simulator.Instance.Textures["antwithfood"];
            else
                Texture2D = Simulator.Instance.Textures["ant"];

            Simulator.Instance.SpriteBatch.Draw(Texture2D, new Vector2(X * 32, Y * 32));
        }
    }
}

