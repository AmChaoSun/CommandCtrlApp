﻿using System;
using C2CApp.Core.Classes.Devices;
using C2CApp.Core.Classes.Devices.Abstractions;
using C2CApp.Core.Interfaces;

namespace C2CApp.Core.Classes.Commands.OldCameraCommands
{
    public class Snapshot : Command
    {
        private OldCamera _device;

        public override Device Receiver 
        { 
            get { return _device; }
            set { _device = (OldCamera)value; } 
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
