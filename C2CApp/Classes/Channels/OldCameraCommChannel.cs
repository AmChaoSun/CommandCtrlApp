using System;
namespace C2CApp.Classes.Channels
{
    public class OldCameraCommChannel : CommChannel
    {
        //params
        private const string CHANNEL = "2009";
        private const string PROTOCOL = "old camera protocol";

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
