using System;
using System.Collections.Generic;
using System.Linq;
using C2CApp.Core.Classes;
using C2CApp.Core.Classes.Commands;
using C2CApp.Core.Test.TestData;
using Xunit;

namespace C2CApp.Core.Test
{
    public class CommandFactoryTest
    {
        [Theory]
        [InlineData("OldCamera", "Snapshot")]
        [InlineData("OldCamera", "ThreeShoot")]
        [InlineData("OldCamera", "TurnOff")]
        [InlineData("OldCamera", "TurnOn")]
        [InlineData("OldCamera", "ZoomIn")]
        [InlineData("OldCamera", "ZoomOut")]
        public void CreateOldCameraCommand(string type, string operation)
        {
            var actual = CommandFactory.CreateCommand(type, operation);
            Assert.Equal(operation,
                actual.GetType().Name);
        }

        [Theory]
        [InlineData("NewCamera", "AmazingFunc")]
        [InlineData("NewCamera", "Snapshot")]
        [InlineData("NewCamera", "ThreeShoot")]
        [InlineData("NewCamera", "TurnOff")]
        [InlineData("NewCamera", "TurnOn")]
        [InlineData("NewCamera", "ZoomIn")]
        [InlineData("NewCamera", "ZoomOut")]
        public void CreateNewCameraCommand(string type, string operation)
        {
            var actual = CommandFactory.CreateCommand(type, operation);
            Assert.Equal(operation,
                actual.GetType().Name);
        }

        [Theory]
        [InlineData("NewCamera", "Wield")]
        [InlineData("OldCamera", "Something")]
        public void CreateInvalidOperation(string type, string operation)
        {
            var actual = CommandFactory.CreateCommand(type, operation);
            Assert.Null(actual);
        }

        [Fact]
        public void CreateInvalidType()
        {
            var actual = CommandFactory.CreateCommand("SomeDevice", "Snapshot");
            Assert.Null(actual);
        }

        [Theory]
        [ClassData(typeof(GetCommandsData))]
        public void GetCommands(string type, List<string> commands)
        {
            var actual = CommandFactory.GetCommands(type).ToList();
            Assert.Equal(commands, actual);
        }

        [Fact]
        public void InvalidTypeGetCommands()
        {
            var actual = CommandFactory.GetCommands("WieldThing");
            Assert.Empty(actual);
        }
    }
}
