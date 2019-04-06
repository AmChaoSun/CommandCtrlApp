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
        public NewCamera(string name, CameraCommChannel channel) : base(name, channel)
        {
        }

        public override IEnumerable<string> GetManual()
        {
            //check connection first
            if (!CheckConnection())
            {
                Connect();
            }

            //get manual
            Console.WriteLine("Get manual in new camera way");
            var methods = GetType().GetMethods(BindingFlags.Instance
                | BindingFlags.Public
                | BindingFlags.DeclaredOnly)
                .Where(x => !x.IsSpecialName && x.Name != "GetManual")
                .Select(x => x.Name);

            return methods;
        }

        public override void TurnOff()
        {
            //check connection first
            if (!CheckConnection())
            {
                Connect();
            }

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
            //check connection first
            if (!CheckConnection())
            {
                Connect();
            }

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
            //check connection first
            if (!CheckConnection())
            {
                Connect();
            }

            Console.WriteLine("Using the method in NewCamera");
            Console.WriteLine("{0} is doing some amazing things", Name);
        }

        //methods from ICamera
        public override void Snapshot()
        {
            //check connection first
            if (!CheckConnection())
            {
                Connect();
            }

            Console.WriteLine("Using the method in NewCamera");
            base.Snapshot();
        }

        public override void ZoomIn()
        {
            //check connection first
            if (!CheckConnection())
            {
                Connect();
            }

            Console.WriteLine("Using the method in NewCamera");
            base.ZoomIn();
        }

        public override void ZoomOut()
        {
            //check connection first
            if (!CheckConnection())
            {
                Connect();
            }

            Console.WriteLine("Using the method in NewCamera");
            base.ZoomOut();
        }
    }
}
