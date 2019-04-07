using System;
using C2CApp.Core.Classes.Commands;
using C2CApp.Core.Classes.Devices.Abstractions;

namespace C2CApp.Core.Interfaces
{
    public interface IInteraction
    {
        void AddDevice();
        void OperateDevice(Device device);
        void RemoveDevice();
        void SelectDevice();
        bool ShowDevices();
        void ShowMenu();
    }
}
