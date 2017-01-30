using System.Collections.Generic;
using F2J2A.CommonSimulator.Pathfind;

namespace F2J2A.CommonSimulator.Core.AI.Commands
{
    //HACK :)
    public class CompositeCommand<T> : ICommand where T : Node
    {
        private List<ICommand>_commands;

        public CompositeCommand()
        {
            _commands = new List<ICommand>();
        }

        public void Add(ICommand command)
        {
            _commands.Add(command);
        }

        public void Execute()
        {
            _commands.ForEach(c => c.Execute());
        }

        public void Undo()
        {
            _commands.ForEach(c => c.Undo());
        }
    }
}