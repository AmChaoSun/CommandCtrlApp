using System;
using C2CApp.Core.Classes;
using C2CApp.Core.Classes.Channels;
using Xunit;

namespace C2CApp.Core.Test
{
    public class CommandCtrlAppTest
    {

        [Fact]
        public void SingletonApp()
        {
            var actual = CommandCtrlApp.Instance;
            var expected = CommandCtrlApp.Instance;
            Assert.Equal(expected, actual);
        }
    }
}
