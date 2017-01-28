using System;

namespace F2J2A.Core
{
	public interface Command
	{
		void Execute();
		void Undo();
	}
}

