﻿using System;
using C2CApp.Core.Classes.Devices;
using C2CApp.Core.Classes.Devices.Abstractions;
using C2CApp.Core.Interfaces;

namespace C2CApp.Core.Classes.Commands.NewCameraCommands
{
    public class Snapshot : Command
    {
        private NewCamera _device;

        public override Device Receiver 
        { 
            get { return _device; }
            set { _device = (NewCamera)value; } 
        }

        public override void Execute()
        {
            //check connection first
            if (!_device.CheckConnection())
            {
                _device.Connect();
            }
            //check status
            if (!_device.CheckStatus())
            {
                _device.TurnOn();
            }

            _device.Snapshot();
        }
    }
}
