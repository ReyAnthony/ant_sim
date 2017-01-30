using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F2J2A.CommonSimulator.Pathfind
{
    public abstract class Node : IDrawable, IComparable
	{
	    public static readonly int DEFAULT_NODE_COST = 1;

	    public int X { get; set;}
		public int Y { get; set;}
	    public int Score { get; set;}
	    public int Cost { get; set;}

	    public Texture2D Texture2D { get; set; }

	    public List<Node> Neighbors { get; private set;}
	    public void addNeighbor(Node node) => this.Neighbors.Add (node);

	    public Node(int abs1,int ord1, int cost)
	    {
	        X = abs1;
	        Y = ord1;
	        Cost = cost;
	        Score = 0;
	        Neighbors = new List<Node> ();
	        Visible = true;
	    }

	    public abstract void Draw(GameTime gameTime);

	    public int DrawOrder { get; }
	    public bool Visible { get; }
	    public event EventHandler<EventArgs> DrawOrderChanged;
	    public event EventHandler<EventArgs> VisibleChanged;

        #region IComparable implementation

        public int CompareTo (object obj)
        {
            var toCompare = obj as Node;
            if (toCompare.Score > Score )
                return -1;
            else if (toCompare.Score == Score)
                return 0;
            else
                return 1;
        }

        #endregion

	    public override bool Equals(object obj)
	    {
	        var node = obj as Node;
	        return node != null && (node.X == X && node.Y == Y);
	    }

	    public override int GetHashCode()
	    {
	        unchecked
	        {
	            return (X * 397) ^ Y;
	        }
	    }
	}
}

