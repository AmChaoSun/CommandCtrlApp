using System;
using C2CApp.Core.Classes.Commands;

namespace C2CApp.Core.Interfaces
{
    public interface IInvoker
    {
        void ExecuteCommand();
        void SetCommand(Command command);
    }
}
