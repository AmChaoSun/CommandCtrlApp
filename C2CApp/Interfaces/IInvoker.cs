using System;
using C2CApp.Classes.Commands;

namespace C2CApp.Interfaces
{
    public interface IInvoker
    {
        void ExecuteCommand();
        void SetCommand(Command command);
    }
}
