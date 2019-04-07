using System;
using C2CApp.Core.Classes.Commands;
using C2CApp.Core.Interfaces;

namespace C2CApp.Core.Classes
{
    public class Invoker : IInvoker
    {
        private Command command;

        public void ExecuteCommand()
        {
            command.Execute();
        }

        public void SetCommand(Command command)
        {
            this.command = command;
        }
    }
}
