using System.Collections;
using System.Collections.Generic;
using System.Linq;
using F2J2A.CommonSimulator.XML;
using static System.Int32;

namespace F2J2A.CommonSimulator.Pathfind
{
    public abstract class Graph
    {
        public Node[,] Nodes { get; private set; }
        protected GameConfig Config { get; }

        private List<Node> _openNodes;
        private int _width;
        private int _height;

        protected Graph(int width, int height, GameConfig config)
        {
            Config = config;
            PopulateNodes(width, height);
        }

        public Node FindNodeFromPosition(int x, int y)
        {
            return Nodes[x, y];
        }

        protected void PopulateNodes(int width, int height)
        {
            _width = width;
            _height = height;

            Nodes = new Node[width,height];
            _openNodes = new List<Node>();

            for (var w = 0; w < width; w++)
            {
                for (var h = 0; h < height; h++)
                {
                    var node = GetNodeForPosition(w, h);
                    Nodes[w, h] = node;
                }
            }

             //add neighbors
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var node = FindNodeFromPosition(x, y);

                    if (x > 0)
                        node.addNeighbor(FindNodeFromPosition(x - 1, y));

                    if (x < width - 1)
                        node.addNeighbor(FindNodeFromPosition(x + 1, y));

                    if (y > 0)
                        node.addNeighbor(FindNodeFromPosition(x, y - 1));

                    if (y < height - 1)
                        node.addNeighbor(FindNodeFromPosition(x, y + 1));
                }
            }
        }

        protected abstract Node GetNodeForPosition(int x, int y);

        private void Init(Node start)
        {
            _openNodes = new List<Node>();

            for (var w = 0; w < _width; w++)
            {
                for (var h = 0; h < _height; h++)
                {
                    var node = FindNodeFromPosition(w, h);
                    node.Score = MaxValue;

                    if (node.Equals(start))
                        node.Score = 0;

                    _openNodes.Add(node);
                }
            }
        }

        public List<Node> GetShortestPath(Node start, Node finish)
        {
            if(start == null || finish == null || start.Equals(finish))
               return new List<Node>();

            Init(start);

            while (_openNodes.Count != 0)
            {
                Node min = _openNodes.Min();
                if (min.Equals(finish))
                    break;

                //get only the neighbors in _openNodes
                var children = min.Neighbors.FindAll(n => _openNodes.Contains(n));
                _openNodes.Remove(min);

                foreach (var child in children)
                {
                    var newScore = min.Score + child.Cost;
                    if (newScore < child.Score)
                        child.Score = newScore;
                }
            }

            var result = new List<Node>() {finish};

            var from = finish;

            while (!from.Equals(start))
            {
                //do not get one that was already done
                var smallests = from.Neighbors.FindAll(n => !result.Contains(n)).ToList();

                //vvvv This is the dumbest behavior ever, long life java vvvv
                //If findAll returns nothing then it silently fails on Min !!!!!!!!!!!!!!!!!!!!
                //WHO CODED THIS ????
                if (smallests.Count() == 0)
                {
                    result = new List<Node>(){start};
                    break;
                }

                var smallest = smallests.Min();
                if(smallest == null)
                    continue;

                from = smallest;

                if (!smallest.Equals(start))
                    result.Add(smallest);

            }

            result.Reverse();
            return result;
        }
    }
}

/*
using System;
using System.Collections.Generic;
using F2J2A.CommonSimulator.XML;

namespace F2J2A.CommonSimulator.Pathfind
{
    public abstract class Graph
    {

        public Node[,] Nodes { get; set; }
        readonly Dictionary<Node, Dictionary<Node, int>> _vertices = new Dictionary<Node, Dictionary<Node, int>>();
        public GameConfig Config { get; set; }
        public Node FindNodeFromPosition(int x, int y) => Nodes[x, y];

        protected Graph(int width, int height, GameConfig config)
        {
            Config = config;
            PopulateNodes(width, height);
        }

        protected void PopulateNodes(int width, int height)
        {
            Nodes = new Node[width,height];

            for (int w = 0; w < width; w++) {
                for (int h = 0; h < height; h++)
                {
                    var node = GetNodeForPosition(w, h);
                    Nodes [w,h] = node;
                    Console.WriteLine ("Creating a node : " + "X : " + w + "Y : " + h);
                }
            }

            for (int w = 0; w < width; w++) {
                for (int h = 0; h < height; h++) {

                    var node = Nodes[w, h];
                    var vertices = new Dictionary<Node, int> ();

                    if (w > 0) {
                        vertices.Add(Nodes[w - 1,h], 1);
                    }

                    if (w < width - 1) {
                        vertices.Add (Nodes [w + 1, h], 1);
                    }

                    if (h > 0) {
                        vertices.Add (Nodes [w, h - 1], 1);
                    }

                    if (h < height - 1) {
                        vertices.Add (Nodes [w, h + 1], 1);
                    }

                    AddVertex (node , vertices);
                    Console.WriteLine ("Added vertice for  : " + w + " : " + h);
                    foreach(Node n in vertices.Keys){
                        Console.WriteLine (" vert : " + n.X + " : " + n.Y);
                    }


                }
            }

        }

        protected abstract Node GetNodeForPosition(int x, int y);

        private void AddVertex(Node node, Dictionary<Node, int> edges) => _vertices[node] = edges;

        private void SetAllNodesToInfinite(Node start, List<Node> nodes, Dictionary<Node, int> distances) {

            //On parcours chacune des vertices
            foreach (var vertex in _vertices)
            {
                //Si c'est le début
                //On etiquette la distance de la vertex comme 0
                //Et on dit que le noeud de depart c'est elle
                //sinon on etiquette la vertex à maxvalue de int vu qu'on l'a traitée
                if (Equals(vertex.Key, start))
                    distances [start] = 0;
                else
                    distances[vertex.Key] = int.MaxValue;

                //Puis on l'ajoute à la list des noeuds
                nodes.Add(vertex.Key);
            }
        }


        public List<Node> GetShortestPath(Node start, Node finish)
        {
            int totalCost = 0;
            var previous = new Dictionary<Node, Node>();
            var distances = new Dictionary<Node, int>(); //why not the distance in the node class ?
            var nodes = new List<Node>();

            List<Node> path = null;
            var startNode = start;

            SetAllNodesToInfinite (start, nodes, distances);

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
                if (Equals(smallest, finish))
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
                path.Reverse();
            return path;
        }
    }


} */




