using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public override IEnumerable<string> GetManual()
        {
            //get manual
            Console.WriteLine("Get manual in new camera way");
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == COMMANDNS
                    where t.Name != "GetManual"
                    select t.Name;
            return q;
        }

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
                status = true;
                Console.WriteLine("{0} turned on", Name);
            }
            else
            {
                Console.WriteLine("{0} has already turned on", Name);
            }
        }

        //new methods in IBetterCamera
        public void AmazingFunc()
        {
            Console.WriteLine("Using the method in NewCamera");
            Console.WriteLine("{0} is doing some amazing things", Name);
        }

        //methods from ICamera
        public override void Snapshot()
        {
            Console.WriteLine("Using the method in NewCamera");
            base.Snapshot();
        }

        public override void ZoomIn()
        {
            Console.WriteLine("Using the method in NewCamera");
            base.ZoomIn();
        }

        public override void ZoomOut()
        {
            Console.WriteLine("Using the method in NewCamera");
            base.ZoomOut();
        }
    }
}
