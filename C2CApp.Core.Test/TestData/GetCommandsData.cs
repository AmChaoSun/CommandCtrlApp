using System;
using System.Collections.Generic;
using Xunit;

namespace C2CApp.Core.Test.TestData
{
    public class GetCommandsData : TheoryData<string, List<string>>
    {
        public GetCommandsData()
        {
            Add("OldCamera", new List<string>
            {
                "Snapshot",
                "ThreeShoot",
                "TurnOff",
                "TurnOn",
                "ZoomIn",
                "ZoomOut"
            });
            Add("NewCamera", new List<string>
            {
                "AmazingFunc",
                "Snapshot",
                "ThreeShoot",
                "TurnOff",
                "TurnOn",
                "ZoomIn",
                "ZoomOut"
            });
        }
    }
}
