using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using C2CApp.Classes.Channels;
using C2CApp.Classes.Devices.Abstractions;
using C2CApp.Interfaces;

namespace C2CApp.Classes.Devices
{
    public class RocketLauncher : Device, IRocketlauncher
    {
        public RocketLauncher(string name, CommChannel channel) : base(name, channel)
        {
        }

        //IDevice implementation
        public override IEnumerable<string> GetManual()
        {
            //check connection first
            if (!CheckConnection())
            {
                Connect();
            }

            //get manual
            Console.WriteLine("Get manual in Rocket Laucher way");
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

        //IRocketlauncher implementation
        public void Launch()
        {
            //check connection first
            if (!CheckConnection())
            {
                Connect();
            }

            Console.WriteLine("launch launch");
        }
    }
}
