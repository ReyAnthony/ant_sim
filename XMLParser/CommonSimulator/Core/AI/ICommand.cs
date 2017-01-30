namespace F2J2A.CommonSimulator.Core.AI
{
	public interface ICommand
	{
		void Execute();
		void Undo();
	}
}

