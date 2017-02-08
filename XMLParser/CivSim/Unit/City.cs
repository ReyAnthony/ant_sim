using F2J2A.CommonSimulator.Core;
using F2J2A.CommonSimulator.Core.Unit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XMLParser.CivSim.Unit
{
    public class City : GameUnit
    {
        private Texture2D _texture2D;

        public City(int x, int y) : base(x, y)
        {
            _texture2D = Simulator.Instance.Textures["ant"];
        }

        public override void Draw(GameTime gameTime)
        {

        }
    }
}