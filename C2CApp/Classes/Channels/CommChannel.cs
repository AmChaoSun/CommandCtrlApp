using System;
using System.Threading;
using C2CApp.Interfaces;

namespace C2CApp.Classes.Channels
{
    //base class for all CommChannels
    public class CommChannel : IComm
    {
        //const params
        private const string CHANNEL = "1024";
        private const string PROTOCOL = "default protocol";

        protected bool connection;

        //properties
        //Protocol and Channel can only be read
        public virtual string Channel
        {
            get
            {
                return CHANNEL;
            }
        }

        public virtual string Protocol
        {
            get
            {
                return PROTOCOL;
            }
        }

        //constructor
        public CommChannel()
        {
            connection = false;
        }

        //methods
        public bool CheckConnection()
        {
            Console.WriteLine("check connection");
            return connection;
        }

        public virtual void Connect()
        {
            Console.WriteLine("connecting via {0} on Channel {1}",
                Protocol,
                Channel);
            Thread.Sleep(3000);
            connection = true;
            Console.WriteLine("connected");
        }

        public virtual void Disconnect()
        {
            connection = false;
            Console.WriteLine("disconnected");
        }
    }
}
