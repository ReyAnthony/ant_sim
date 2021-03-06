﻿using System.Collections.Generic;

namespace F2J2A.CommonSimulator.Core.AI.Commands
{
    public class CompositeCommand : ICommand
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