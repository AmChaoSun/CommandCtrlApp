using System;
using System.Collections.Generic;

namespace C2CApp.Interfaces
{
    public interface IDevice
    {
        bool CheckConnection();
        void Connect();
        void Disconnect();
        IEnumerable<string> GetManual();
        void TurnOff();
        void TurnOn();
    }
}
