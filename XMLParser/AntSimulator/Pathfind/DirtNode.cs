using F2J2A.CommonSimulator.Core;
using F2J2A.CommonSimulator.Pathfind;
using Microsoft.Xna.Framework;

namespace F2J2A.AntSimulator.Pathfind
{
    public class DirtNode : Node
    {
	    public DirtNode(int Abs, int Ord, int cost) : base(Abs, Ord, cost)
	    {
	        Cost = cost;
	    }

        public override void Draw(GameTime gameTime)
        {
            if(Cost > 1)
                Texture2D = Simulator.Instance.Textures["dirt"];
            else
                Texture2D = Simulator.Instance.Textures["background"];

            Simulator.Instance.SpriteBatch.Draw(Texture2D, new Vector2(X * 32, Y * 32));
        }
	}
}

