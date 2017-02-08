using F2J2A.CommonSimulator.Core;
using F2J2A.CommonSimulator.Core.Unit;
using Microsoft.Xna.Framework;

namespace F2J2A.AntSimulator.Unit
{
    public class AntCorpse : GameUnit
    {

        public AntCorpse(int x, int y) : base(x, y)
        {
            Texture2D = Simulator.Instance.Textures["antcorpse"];
        }

        public override void Draw(GameTime gameTime)
        {
            Simulator.Instance.SpriteBatch.Draw(Texture2D, new Vector2(X * 32, Y * 32));
        }
    }
}

