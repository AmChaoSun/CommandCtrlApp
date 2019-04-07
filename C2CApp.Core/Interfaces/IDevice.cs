using System;
using System.Collections.Generic;

namespace C2CApp.Core.Interfaces
{
    public interface IDevice
    {
        bool CheckConnection();
        //check power on/off
        bool CheckStatus();
        void Connect();
        void Disconnect();
        void TurnOff();
        void TurnOn();
    }
}
