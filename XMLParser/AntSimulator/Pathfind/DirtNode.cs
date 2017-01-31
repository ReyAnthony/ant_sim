using F2J2A.CommonSimulator.Core;
using F2J2A.CommonSimulator.Pathfind;
using Microsoft.Xna.Framework;

namespace F2J2A.AntSimulator.Pathfind
{
    public class DirtNode : Node
    {
        public static readonly int FULL_NODE_COST = 2;

        public DirtNode(int x, int y, int cost) : base(x, y, cost)
	    {
	        Cost = cost;
	    }

        public override void Draw(GameTime gameTime)
        {
            if(Cost > DEFAULT_NODE_COST)
                Texture2D = Simulator.Instance.Textures["dirt"];
            else
                Texture2D = Simulator.Instance.Textures["background"];

            Simulator.Instance.SpriteBatch.Draw(Texture2D, new Vector2(X * 32, Y * 32));
        }
	}
}

