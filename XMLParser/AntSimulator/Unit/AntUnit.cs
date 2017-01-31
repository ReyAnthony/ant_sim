using F2J2A.CommonSimulator.Core;
using F2J2A.CommonSimulator.Pathfind;
using Microsoft.Xna.Framework;

namespace F2J2A.AntSimulator.Unit
{
    public class AntUnit : Node
    {
        public FoodUnit TransportedFood { get; set; }
        public NestUnit BaseNest;
        public int Health;

        public AntUnit() : base(0, 0, 0)
        {
            Texture2D = Simulator.Instance.Textures["ant"];
        }

        public AntUnit(int x, int y, NestUnit baseNest, int life) : base(x, y, 0)
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

