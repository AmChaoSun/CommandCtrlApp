using System;
using C2CApp.Classes.Commands;

namespace C2CApp.Interfaces
{
    public interface IInvolker
    {
        void SetCommand(Command command);
        void ExecuteCommand();
    }
}
