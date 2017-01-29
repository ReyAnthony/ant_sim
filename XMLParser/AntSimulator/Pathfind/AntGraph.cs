using XMLParser;

namespace F2J2A.Pathfind
{
	class AntGraph : Graph
	{
	    private AntGameConfig config;

	    public AntGraph(AntGameConfig config, int width, int height)
	    {
	        this.config = config;
	        populateNodes(width, height);
	    }

	    protected override Node getNodeForPosition(int x, int y)
	    {
	        if(y == 0)
	            return new NoStuffNode(x, y);

	        if (config.Nests.FindAll(n => (n.PosX == x && n.PosY == y)).Count > 0)
	            return new NestNode(x, y);

	        return new DirtNode(x, y);
	    }
	}

}


