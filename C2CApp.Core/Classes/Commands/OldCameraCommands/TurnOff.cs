﻿using System;
using C2CApp.Core.Classes.Devices;
using C2CApp.Core.Classes.Devices.Abstractions;

namespace C2CApp.Core.Classes.Commands.OldCameraCommands
{
    public class TurnOff: Command
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
                return;
            }

            _device.TurnOff();
        }
    }
}
