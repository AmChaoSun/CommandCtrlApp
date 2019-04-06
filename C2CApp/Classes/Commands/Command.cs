using System;
using C2CApp.Classes.Devices.Abstractions;
using C2CApp.Interfaces;

namespace C2CApp.Classes.Commands
{
    public abstract class Command: ICommand
    {
        //params
        private Device receiver;

        //constructor
        public Command(Device receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }
}
