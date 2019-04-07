using System;
using System.Collections.Generic;
using C2CApp.Core.Classes.Devices.Abstractions;

namespace C2CApp.Core.Interfaces
{
    public interface IDeviceRepository
    {
        Device Add(Device device);
        Device Create(string type, string name);
        Device Get(string name);
        IEnumerable<Device> GetAll();
        IEnumerable<string> GetAvailableTypes();
        void Remove(string name);
    }
}
