using System;
using System.Collections.Generic;

namespace F2J2A.Pathfind
{
    public abstract class Graph
	{

		public Node[,] nodes { get; set; }
		readonly Dictionary<Node, Dictionary<Node, int>> _vertices = new Dictionary<Node, Dictionary<Node, int>>();

	    protected void populateNodes(int width, int height)
	    {
	        nodes = new Node[width,height];

	        for (int w = 0; w < width; w++) {
	            for (int h = 0; h < height; h++)
	            {
	                var node = getNodeForPosition(w, h);
	                nodes [w,h] = node;
	                Console.WriteLine ("Creating a node : " + "X : " + w + "Y : " + h);
	            }
	        }

	        for (int w = 0; w < width; w++) {
	            for (int h = 0; h < height; h++) {

	                var node = nodes[w, h];
	                var vertices = new Dictionary<Node, int> ();

	                if (w > 0) {
	                    vertices.Add(nodes[w - 1,h], 1);
	                }

	                if (w < width - 1) {
	                    vertices.Add (nodes [w + 1, h], 1);
	                }

	                if (h > 0) {
	                    vertices.Add (nodes [w, h - 1], 1);
	                }

	                if (h < height - 1) {
	                    vertices.Add (nodes [w, h + 1], 1);
	                }

	                addVertex (node , vertices);
	                Console.WriteLine ("Added vertice for  : " + w + " : " + h);
	                foreach(Node n in vertices.Keys){
	                    Console.WriteLine (" vert : " + n.Abs + " : " + n.Ord);
	                }


	            }
	        }

	    }

	    protected abstract Node getNodeForPosition(int x, int y);

		private void addVertex(Node node, Dictionary<Node, int> edges) => _vertices[node] = edges;

		private void setAllNodesToInfinite(Node start, List<Node> nodes, Dictionary<Node, int> distances) {

			//On parcours chacune des vertices
			foreach (var vertex in _vertices)
			{
				//Si c'est le début
				//On etiquette la distance de la vertex comme 0
				//Et on dit que le noeud de depart c'est elle
				//sinon on etiquette la vertex à maxvalue de int vu qu'on l'a traitée
				if (vertex.Key == start)
					distances [start] = 0;
				else
					distances[vertex.Key] = int.MaxValue;

				//Puis on l'ajoute à la list des noeuds
				nodes.Add(vertex.Key);
			}
		}


		public Dictionary<List<Node>,int> getShortestPath(Node start, Node finish)
		{
			int totalCost = 0;
			var previous = new Dictionary<Node, Node>(); 
			var distances = new Dictionary<Node, int>(); //why not the distance in the node class ?
			var nodes = new List<Node>();

			List<Node> path = null;
			var startNode = start; 

			setAllNodesToInfinite (start, nodes, distances);

			while (nodes.Count != 0)
			{
				//Alors on les trie (du plus petit au plus grand ? pas compris)
				//C'est bien joli mais on est pas tous des génie ;)
				nodes.Sort((x, y) => distances[x] - distances[y]);

				//On chope le plus petit (on à classé par distance faut croire) 
				var smallest = nodes[0];
				//on le retire de l'openSet
				nodes.Remove(smallest);

				//si c'est la fin
				if (smallest == finish)
				{
					//On crée le path
					path = new List<Node>();

					//tant que le closed set contiens le smallest
					while (previous.ContainsKey(smallest))
					{
						path.Add (smallest);
						smallest = previous[smallest];
					}

					break;
				}

				//si le plus petit c'est l'infini, bon bah t'es niqué
				if (distances[smallest] == int.MaxValue)
					break;


				//on checke tout les voisins du plus petit
				foreach (var neighbor in _vertices[smallest])
				{
					int newCost = distances[smallest] + neighbor.Value;
					if (newCost < distances[neighbor.Key])
					{
						distances[neighbor.Key] = newCost;
						previous[neighbor.Key] = smallest;
						totalCost = totalCost + newCost;
					}
				}
			}

			if (path != null)
				path.Add(startNode);

			var root = new Dictionary<List<Node>, int>();
			root.Add(path,totalCost);
			return root;
		}
	}


}


