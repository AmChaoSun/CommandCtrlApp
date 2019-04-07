using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using C2CApp.Core.Classes.Channels;
using C2CApp.Core.Interfaces;

namespace C2CApp.Core.Classes.Devices.Abstractions
{
    public abstract class Device : IDevice
    {
        //params
        //false means power off
        protected bool status;

        protected readonly CommChannel channel;

        //properties
        public string Name { get; set; }

        //constructors
        protected Device(string name, CommChannel channel)
        {
            Name = name;
            this.channel = channel;
            status = false;
        }

        //implement Idevice
        //abstract implementations
        public abstract void TurnOff();
        public abstract void TurnOn();


        public bool CheckConnection()
        {
            return channel.CheckConnection();
        }

        //check power on/off
        public bool CheckStatus()
        {
            return status;
        }

        public void Connect()
        {
            channel.Connect();
        }

        public void Disconnect()
        {
            channel.Disconnect();
        }


    }
}
