using System;
using Microsoft.Xna.Framework;

namespace F2J2A.Pathfind
{
	public class GraphDrawer : IDrawable
	{

		private Graph graph;

		public GraphDrawer (Graph graph)
		{
			this.graph = graph;
		}

		#region IDrawable implementation

		public event EventHandler<EventArgs> DrawOrderChanged;

		public event EventHandler<EventArgs> VisibleChanged;

		public void Draw (GameTime gameTime)
		{
			foreach (Node n in graph.nodes) {
				n.Draw (gameTime);
			}
		}

		public int DrawOrder {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool Visible {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion
	}
}

