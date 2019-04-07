using System;
using System.Collections.Generic;
using C2CApp.Classes.Devices.Abstractions;
using C2CApp.Interfaces;

namespace C2CApp.Classes
{
    public class DeviceRepository: IDeviceRepository
    {
        private Dictionary<string, Device> devices;
        public DeviceRepository()
        {
            devices = new Dictionary<string, Device>();
        }

        public Device Add(Device device)
        {
            //if exists, replace it
            if (devices.ContainsKey(device.Name))
            {
                devices[device.Name] = device;
            }
            devices.Add(device.Name, device);

            Console.WriteLine("\n{0} added\n", device.Name);

            return devices[device.Name];
        }

        public Device Create(string type, string name)
        {
            Device newDevice = DeviceFactory.CreateDevice(type, name);
            return newDevice; 
        }

        public Device Get(string name)
        {
            //if found
            if (devices.TryGetValue(name, out Device device))
            {
                return device;
            }
            //if not found
            Console.WriteLine("\ndevice {0} not found\n", name);
            return null;
        }

        public IEnumerable<Device> GetAll()
        {
            return devices.Values;
        }

        public IEnumerable<string> GetAvailableTypes()
        {
            return DeviceFactory.GetAvailableTypes();
        }

        public void Remove(string name)
        {
            if (devices.ContainsKey(name))
            {
                devices.Remove(name);
                Console.WriteLine("\n{0} removed\n", name);
            }
            Console.WriteLine("\n{0} not found\n", name);
        }
    }
}
