using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2J2A.Pathfind
{
	class Node
	{
		public int Abs { get; set;}
		public int Ord { get; set;}

		public Node(int abs1,int ord1)
		{
			Abs = abs1;
			Ord = ord1;
		}
	}
}

