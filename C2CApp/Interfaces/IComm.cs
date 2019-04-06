using System;
namespace C2CApp.Interfaces
{
    //interface for communication
    public interface IComm
    {
        bool CheckConnection();
        void Connect();
        void Disconnect();
    }
}
