using System;
using System.Collections.Generic;
using System.Linq;
using C2CApp.Core.Classes;
using C2CApp.Core.Classes.Devices.Abstractions;
using Xunit;

namespace C2CApp.Core.Test
{
    public class DeviceRepositoryTest
    {
        //methods from IDeviceRepository
        //Device Add(Device device);
        //Device Create(string type, string name);(tested in factory)
        //Device Get(string name);
        //IEnumerable<Device> GetAll();
        //IEnumerable<string> GetAvailableTypes();
        //void Remove(string name);

        [Fact]
        public void Add()
        {
            var repo = new DeviceRepository();
            var device = DeviceFactory.CreateDevice("OldCamera", "old camera");

            Assert.Equal(device, repo.Add(device));
        }

        [Fact]
        public void AddDuplicateName()
        {
            var repo = new DeviceRepository();
            //add old one
            var oldDevice = DeviceFactory.CreateDevice("OldCamera", "old camera");
            repo.Add(oldDevice);
            //make a new one with duplicate name should replace the old one
            var newDevice = DeviceFactory.CreateDevice("NewCamera", "old camera");
            Assert.Equal(newDevice, repo.Add(newDevice));
        }

        [Theory]
        [InlineData("OldCamera", "old camera")]
        [InlineData("NewCamera", "new camera")]
        public void Get(string type, string name)
        {
            //add one first
            var repo = new DeviceRepository();
            var device = DeviceFactory.CreateDevice(type, name);
            repo.Add(device);

            //get it
            Assert.Equal(device, repo.Get(name));
        }

        [Fact]
        public void GetNotExistedDevice()
        {
            var repo = new DeviceRepository();
            //add one
            var oldDevice = DeviceFactory.CreateDevice("OldCamera", "old camera");
            repo.Add(oldDevice);

            Assert.Null(repo.Get("somethingNotExisted"));
        }

        [Fact]
        public void GetAll()
        {
            var repo = new DeviceRepository();
            //add two
            var oldDevice = DeviceFactory.CreateDevice("OldCamera", "old camera");
            var newDevice = DeviceFactory.CreateDevice("NewCamera", "new camera");
            repo.Add(oldDevice);
            repo.Add(newDevice);

            List<Device> devices = new List<Device>
            {
                oldDevice,
                newDevice
            };

            Assert.Equal(devices, repo.GetAll().ToList());
        }

        [Theory]
        [InlineData("OldCamera", "old camera")]
        [InlineData("NewCamera", "new camera")]
        public void Remove(string type, string name)
        {
            var repo = new DeviceRepository();
            //add one
            var device = DeviceFactory
                .CreateDevice(type, name);
            repo.Add(device);

            //remove
            repo.Remove(name);

            Assert.Empty(repo.GetAll());
        }

        [Fact]
        public void RemoveNotExisted()
        {
            var repo = new DeviceRepository();
            //add one
            var device = DeviceFactory
                .CreateDevice("OldCamera", "old camera");
            repo.Add(device);

            //remove
            repo.Remove("nameNotExisted");

            Assert.Single(repo.GetAll());
        }
    }
}
