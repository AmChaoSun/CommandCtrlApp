using System;
namespace C2CApp.Classes.Channels
{
    public class CameraCommChannel : CommChannel
    {
        //params
        private const string CHANNEL = "2019";
        private const string PROTOCOL = "camera protocol";

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
