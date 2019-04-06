using System;
using System.Reflection;
using C2CApp.Classes.Channels;
using C2CApp.Classes.Devices.Abstractions;
using C2CApp.Interfaces;

namespace C2CApp.Classes
{
    public static class DeviceFactory
    {
        const string ASSEMBLY = "C2CApp";
        const string DEVICENS = "C2CApp.Classes.Devices";
        const string CHANNELNS = "C2CApp.Classes.Channels";

        public static Device CreateDevice(string type, string name)
        {
            string instanceName = String.Format("{0}.{1}", DEVICENS, type);
            string commInstanceName = String
                .Format("{0}.{1}CommChannel", CHANNELNS, type);

            //use reflection to create channel
            var channel = (CommChannel)Assembly.Load(ASSEMBLY)
                .CreateInstance(commInstanceName);
            //if related channel has not been defined, device cannot be created
            if(channel == null)
            {
                return null;
            }
            channel.Connect();

            //create and return device
            Object[] args = { name, channel };
            return (Device)Assembly.Load(ASSEMBLY).CreateInstance(instanceName,
                false, (BindingFlags)0, null, args, null, null);
        }
    }
}
