﻿using System;
using C2CApp.Classes.Devices;
using C2CApp.Classes.Devices.Abstractions;

namespace C2CApp.Classes.Commands.NewCameraCommands
{
    public class ThreeShoot: Command
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
            _device.Snapshot();
            _device.Snapshot();
        }
    }
}
