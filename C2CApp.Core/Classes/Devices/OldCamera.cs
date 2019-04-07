using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using C2CApp.Core.Classes.Channels;
using C2CApp.Core.Classes.Devices.Abstractions;

namespace C2CApp.Core.Classes.Devices
{
    public class OldCamera : Camera
    {
        //const
        private const string COMMANDNS = "C2CApp.Core.Classes.Commands.OldCameraCommands";

        public OldCamera(string name, OldCameraCommChannel channel) : base(name, channel)
        {
        }

        //IDevice implementation

        //public override IEnumerable<string> GetManual()
        //{
        //    //get manual
        //    Console.WriteLine("get manual in old camera way");
        //    //get methods
        //    //var methods = GetType().GetMethods(BindingFlags.Instance
        //    //| BindingFlags.Public
        //    //| BindingFlags.DeclaredOnly)
        //    //.Where(x => !x.IsSpecialName && x.Name != "GetManual")
        //    //.Select(x => x.Name);

        //    var q = from t in Assembly.GetExecutingAssembly().GetTypes()
        //            where t.IsClass && t.Namespace == COMMANDNS
        //            where t.Name != "GetManual"
        //            select t.Name;
        //    return q;
        //}

        public override void TurnOff()
        {
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
        }

        public override void TurnOn()
        {
            //turn on
            Console.WriteLine("turn on old camera");
            //if turned off, then turn on
            if (!status)
            {
                //assume turn on needs 3s
                Thread.Sleep(3000);
                status = true;
                Console.WriteLine("{0} turned on", Name);
            }
            else
            {
                Console.WriteLine("{0} has already turned on", Name);
            }
        }


        //ICamera implementation
        public override void Snapshot()
        {
            Console.WriteLine("using the method in OldCamera");
            base.Snapshot();
        }

        public override void ZoomIn()
        {
            Console.WriteLine("using the method in OldCamera");
            base.ZoomIn();
        }

        public override void ZoomOut()
        {
            Console.WriteLine("using the method in OldCamera");
            base.ZoomOut();
        }
    }
}
