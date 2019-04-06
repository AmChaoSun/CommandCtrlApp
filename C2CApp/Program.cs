using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using C2CApp.Classes.Channels;
using C2CApp.Classes.Devices;
using C2CApp.Classes.Devices.Abstractions;

namespace C2CApp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var channel = new CameraCommChannel();
            //channel.Connect();

            //Device camera = new OldCamera("old camera", channel);
            ////camera.GetManual();
            ////camera.GetType().GetMethod("Snapshot").Invoke(camera, null);
            //camera.TurnOn();

            //Device camera1 = new OldCamera("old camera1", channel);
            //camera1.TurnOff();

            string nspace = "C2CApp.Classes.Devices";

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == nspace
                    where t.Name != "<>c"
                    select t.Name;
            q.ToList().ForEach(t => Console.WriteLine(t));

        }
    }
}
