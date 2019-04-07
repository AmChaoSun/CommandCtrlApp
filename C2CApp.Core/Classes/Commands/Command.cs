using System;
using C2CApp.Core.Classes.Devices.Abstractions;
using C2CApp.Core.Interfaces;

namespace C2CApp.Core.Classes.Commands
{
    public abstract class Command: ICommand
    {
        //property
        public abstract Device Receiver { get; set; }

        public abstract void Execute();
    }
}
