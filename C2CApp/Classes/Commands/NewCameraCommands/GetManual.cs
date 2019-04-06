using System;
using System.Collections.Generic;
using System.Linq;
using C2CApp.Classes.Devices;
using C2CApp.Classes.Devices.Abstractions;

namespace C2CApp.Classes.Commands.NewCameraCommands
{
    public class GetManual : Command
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

            var options = _device.GetManual().ToList();
            options.Add("Back");

            foreach (string option in options)
            {
                Console.WriteLine(option);
            }
        }
    }
}
