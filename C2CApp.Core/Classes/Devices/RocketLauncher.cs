﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using C2CApp.Core.Classes.Channels;
using C2CApp.Core.Classes.Devices.Abstractions;
using C2CApp.Core.Interfaces;

namespace C2CApp.Core.Classes.Devices
{
    public class RocketLauncher : Device, IRocketlauncher
    {
        public RocketLauncher(string name, CommChannel channel) : base(name, channel)
        {
        }

        //IDevice implementation
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
