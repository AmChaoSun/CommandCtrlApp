using System;
using C2CApp.Classes.Commands;
using C2CApp.Interfaces;

namespace C2CApp.Classes
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
