using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using C2CApp.Classes.Channels;
using C2CApp.Classes.Devices.Abstractions;
using C2CApp.Interfaces;

namespace C2CApp.Classes.Devices
{
    public class NewCamera : Camera, IBetterCamera
    {
        //const
        private const string COMMANDNS = "C2CApp.Classes.Commands.NewCameraCommands";

        public NewCamera(string name, NewCameraCommChannel channel) : base(name, channel)
        {
        }

        //IDevice implementation
        public override void TurnOff()
        {
            Console.WriteLine("turn off new camera");
            //if turned on, then turn off
            if (status)
            {
                status = false;
                Console.WriteLine("{0} turned off", Name);
            }
            else
            {
                Console.WriteLine("{0} has already turned off", Name);
            }

            //disconnect after turn off
            Disconnect();
        }

        public override void TurnOn()
        {
            Console.WriteLine("turn on new camera");
            //if turned off, then turn on
            if (!status)
            {
                //assume turn on needs 2s
                Thread.Sleep(2000);
                status = true;
                Console.WriteLine("{0} turned on", Name);
            }
            else
            {
                Console.WriteLine("{0} has already turned on", Name);
            }
        }

        //ICamera Implementation
        public override void Snapshot()
        {
            Console.WriteLine("using the method in NewCamera");
            base.Snapshot();
        }

        public override void ZoomIn()
        {
            Console.WriteLine("using the method in NewCamera");
            base.ZoomIn();
        }

        public override void ZoomOut()
        {
            Console.WriteLine("using the method in NewCamera");
            base.ZoomOut();
        }

        //IBetterCamera implementation
        public void AmazingFunc()
        {
            Console.WriteLine("using the method in NewCamera");
            Console.WriteLine("{0} is doing some amazing things", Name);
        }
    }
}
