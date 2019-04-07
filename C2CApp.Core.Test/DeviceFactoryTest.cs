using System;
using System.Collections.Generic;
using System.Linq;
using C2CApp.Core.Classes;
using C2CApp.Core.Classes.Channels;
using C2CApp.Core.Classes.Devices;
using Xunit;

namespace C2CApp.Core.Test
{
    public class DeviceFactoryTest
    {
        [Fact]
        public void CreateNewCamera()
        {
            var device = DeviceFactory.CreateDevice("NewCamera", "my new camera");
            var camera = new NewCamera("my new camera", new NewCameraCommChannel());
            //check name
            Assert.Equal(camera.Name, device.Name);
            //check type
            Assert.Equal(camera.GetType(), device.GetType());
            //check status
            Assert.Equal(camera.CheckStatus(), device.CheckStatus());
            //check Connection
            Assert.Equal(camera.CheckConnection(), device.CheckConnection());
        }

        [Fact]
        public void CreateOldCamera()
        {
            var device = DeviceFactory.CreateDevice("OldCamera", "my old camera");
            var camera = new OldCamera("my old camera", new OldCameraCommChannel());
            //check name
            Assert.Equal(camera.Name, device.Name);
            //check type
            Assert.Equal(camera.GetType(), device.GetType());
            //check status
            Assert.Equal(camera.CheckStatus(), device.CheckStatus());
            //check Connection
            Assert.Equal( camera.CheckConnection(), device.CheckConnection());
        }

        [Fact]
        public void CreateRocketLauncher()
        {
            var device = DeviceFactory.CreateDevice("RocketLauncher", "my RocketLauncher");
            var launcher = new RocketLauncher("my RocketLauncher", new RocketLauncherCommChannel());
            //check name
            Assert.Equal(launcher.Name, device.Name);
            //check type
            Assert.Equal(launcher.GetType(), device.GetType());
            //check status
            Assert.Equal(launcher.CheckStatus(), device.CheckStatus());
            //check Connection
            Assert.Equal(launcher.CheckConnection(), device.CheckConnection());
        }

        [Fact]
        public void CreateInvalidType()
        {
            var device = DeviceFactory.CreateDevice("SomeWieldThing", "my RocketLauncher");
            Assert.Null(device);
        }

        [Fact]
        public void GetAvailableTypes()
        {
            var expectedTypes = new List<string>() { "NewCamera", "OldCamera", "RocketLauncher" };
            var actualTypes = DeviceFactory.GetAvailableTypes().ToList();
            Assert.Equal(expectedTypes, actualTypes);
        }
    }
}
