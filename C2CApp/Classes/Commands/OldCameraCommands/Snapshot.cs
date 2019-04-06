using System;
using C2CApp.Classes.Devices;
using C2CApp.Classes.Devices.Abstractions;
using C2CApp.Interfaces;

namespace C2CApp.Classes.Commands.OldCameraCommands
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

            _device.Snapshot();
        }
    }
}
