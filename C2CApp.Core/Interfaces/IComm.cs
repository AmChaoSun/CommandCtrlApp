using System;
namespace C2CApp.Core.Interfaces
{
    //interface for communication
    public interface IComm
    {
        bool CheckConnection();
        void Connect();
        void Disconnect();
    }
}
