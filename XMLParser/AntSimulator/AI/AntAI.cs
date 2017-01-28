using System;
using F2J2A.Core;

namespace F2J2A
{
	public class AntAI : AI
	{
		public AntAI ()
		{
		}

		#region AI implementation

		public Command getNextAction ()
		{
			return new MoveTo ();
		}

		#endregion
	}
}

