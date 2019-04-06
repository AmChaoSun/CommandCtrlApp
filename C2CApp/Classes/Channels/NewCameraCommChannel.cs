using System;
namespace C2CApp.Classes.Channels
{
    public class NewCameraCommChannel : CommChannel
    {
        //params
        private const string CHANNEL = "2019";
        private const string PROTOCOL = "new camera protocol";

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
