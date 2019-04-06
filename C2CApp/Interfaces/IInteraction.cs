using System;
using C2CApp.Classes.Commands;
using C2CApp.Classes.Devices.Abstractions;

namespace C2CApp.Interfaces
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
