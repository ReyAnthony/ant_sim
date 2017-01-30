using F2J2A.AntSimulator.Config;
using F2J2A.CommonSimulator.Pathfind;

namespace F2J2A.AntSimulator.Pathfind
{
    public class AntGraph : Graph
	{
	    public AntGraph(AntGameConfig config, int width, int height) : base(width, height, config){}

	    protected override Node GetNodeForPosition(int x, int y)
	    {

	        if (y == 0 || ((AntGameConfig) Config).Nests.FindAll(n => (n.PosX == x && n.PosY == y)).Count > 0)
	        {
	            //TODO also do the neighbors of the nest
	            //TODO should cost 1 because they will never go the othr way as it costs "infinitely" more
	            return new DirtNode(x, y, Node.DEFAULT_NODE_COST);
	        }

	        return new DirtNode(x, y, DirtNode.FULL_NODE_COST);
	    }
	}

}


