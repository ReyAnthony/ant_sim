using System;
using F2J2A.Core;

namespace F2J2A
{
	public class MoveTo : Command
	{
		public MoveTo ()
		{
		}

		#region Command implementation

		public void Execute ()
		{
			Console.WriteLine ("Moves the ant to X Y");
		}

		public void Undo ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

