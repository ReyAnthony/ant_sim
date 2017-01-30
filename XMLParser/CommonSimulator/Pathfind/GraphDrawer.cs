using System;
using Microsoft.Xna.Framework;

namespace F2J2A.CommonSimulator.Pathfind
{
	public class GraphDrawer : IDrawable
	{

		private Graph _graph;

		public GraphDrawer (Graph graph)
		{
			this._graph = graph;
		}

		#region IDrawable implementation

		public event EventHandler<EventArgs> DrawOrderChanged;

		public event EventHandler<EventArgs> VisibleChanged;

		public void Draw (GameTime gameTime)
		{
			foreach (var n in _graph.Nodes) {
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

