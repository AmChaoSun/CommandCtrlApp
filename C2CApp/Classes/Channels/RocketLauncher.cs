using System;
namespace C2CApp.Classes.Channels
{
    public class RocketLauncherCommChannel : CommChannel
    {
        //params
        private const string CHANNEL = "2016";
        private const string PROTOCOL = "rocket launcher protocol";

        //override properties
        public override string Channel
        {
            get
            {
                return CHANNEL;
            }
        }

        public override string Protocol
        {
            get
            {
                return PROTOCOL;
            }
        }

    }
}
