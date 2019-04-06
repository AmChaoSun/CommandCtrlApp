using System;
using C2CApp.Classes.Channels;
using C2CApp.Interfaces;

namespace C2CApp.Classes.Devices.Abstractions
{
    public abstract class Camera : Device, ICamera
    {
        protected Camera(string name, CommChannel channel) : base(name, channel)
        {
        }

        //implement ICamera
        public virtual void Snapshot()
        {
            Console.WriteLine("{0} takes a photo", Name);
        }

        public virtual void ZoomIn()
        {
            Console.WriteLine("{0} zooming in", Name);
        }

        public virtual void ZoomOut()
        {
            Console.WriteLine("{0} zooming out", Name);
        }
    }
}
