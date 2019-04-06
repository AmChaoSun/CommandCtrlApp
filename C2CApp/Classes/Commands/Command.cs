using System;
using C2CApp.Classes.Devices.Abstractions;
using C2CApp.Interfaces;

namespace C2CApp.Classes.Commands
{
    public abstract class Command: ICommand
    {
        //property
        public abstract Device Receiver { get; set; }

        public abstract void Execute();
    }
}
