using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Patterns.Command
{
    public class CommandInvoker
    {
        private readonly Queue<ICommand> _commands = new();
        public void AddCommand(ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            _commands.Enqueue(command);
        }

        public void ExecuteCommands()
        {
            while (_commands.Count > 0)
            {
                var command = _commands.Dequeue();
                command.Execute();
            }
            
        }
    }
}
