using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using C2CApp.Classes.Channels;
using C2CApp.Classes.Devices.Abstractions;
using C2CApp.Interfaces;

namespace C2CApp.Classes
{
    public static class DeviceFactory
    {
        private const string ASSEMBLY = "C2CApp";
        private const string DEVICENS = "C2CApp.Classes.Devices";
        private const string CHANNELNS = "C2CApp.Classes.Channels";

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

        public static IEnumerable<string> GetAvailableTypes()
        {
            var types = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == DEVICENS
                    where t.Name != "<>c"
                    select t.Name;
            return types;
        }
    }
}
