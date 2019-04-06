using System;
using C2CApp.Classes.Commands;
using C2CApp.Classes.Devices.Abstractions;

namespace C2CApp.Interfaces
{
    public interface IInteraction
    {
        void SelectDevice();
        void AddDevice();
        void RemoveDevice();
        void OperateDevice(Device device);
        bool ShowDevices();
        void ShowMenu();
    }
}
