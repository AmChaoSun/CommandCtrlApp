using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using C2CApp.Classes.Channels;
using C2CApp.Classes.Devices.Abstractions;

namespace C2CApp.Classes.Devices
{
    public class OldCamera : Camera
    {
        public OldCamera(string name, CameraCommChannel channel) : base(name, channel)
        {
        }

        //implement IDevice
        public override IEnumerable<string> GetManual()
        {
            //check connection first
            if (!CheckConnection())
            {
                Connect();
            }

            //get manual
            Console.WriteLine("Get manual in old camera way");
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

            Console.WriteLine("turn off old camera");
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

            //turn on
            Console.WriteLine("turn on old camera");
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


        //methods from ICamera
        public override void Snapshot()
        {
            //check connection first
            if (!CheckConnection())
            {
                Connect();
            }

            Console.WriteLine("Using the method in OldCamera");
            base.Snapshot();
        }

        public override void ZoomIn()
        {
            //check connection first
            if (!CheckConnection())
            {
                Connect();
            }

            Console.WriteLine("Using the method in OldCamera");
            base.ZoomIn();
        }

        public override void ZoomOut()
        {
            //check connection first
            if (!CheckConnection())
            {
                Connect();
            }

            Console.WriteLine("Using the method in OldCamera");
            base.ZoomOut();
        }
    }
}
