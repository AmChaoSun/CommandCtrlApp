using System;
using System.Collections.Generic;
using System.Linq;
using C2CApp.Classes.Devices;
using C2CApp.Classes.Devices.Abstractions;

namespace C2CApp.Classes.Commands.OldCameraCommands
{
    public class GetManual : Command
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

            var options = _device.GetManual().ToList();
            options.Add("Back");

            foreach (string option in options)
            {
                Console.WriteLine(option);
            }
        }
    }
}
