using Microsoft.Xna.Framework;

namespace F2J2A.Pathfind
{
    public interface Node : IDrawable
	{
		int Abs { get; set;}
		int Ord { get; set;}
	}
}

