using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using C2CApp.Classes.Commands;
using C2CApp.Classes.Devices.Abstractions;
using C2CApp.Interfaces;

namespace C2CApp.Classes
{
    //implement simple singleton, not thread safe
    //however this is a simple single thread app
    public sealed class CommandCtrlApp : ICommandCtrlApp
    {
        //consts
        private readonly string[] MENUOPTIONS = { "add device",
            "remove device",
            "select device",
            "exit"};

        //static
        private static CommandCtrlApp instance = null;

        private Involker involker;
        private readonly DeviceRepository deviceRepo;


        //constructors
        private CommandCtrlApp()
        {
            involker = new Involker();
            deviceRepo = new DeviceRepository();
        }

        //static method(singleton)
        public static CommandCtrlApp Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommandCtrlApp();
                }
                return instance;
            }
        }

        //implement methods
        public void AddDevice()
        {
            //show allowed device types
            Console.WriteLine("\nselect from the following types");
            //get
            var types = DeviceFactory.GetAvailableTypes();
            //show
            types.ToList().ForEach(t => Console.WriteLine(t));

            //iput device type, if invalid return to upper menu
            Console.WriteLine("select: ");
            string type = Console.ReadLine();

            //invalid type
            if (!types.Any(x => x == type))
            {
                Console.WriteLine("invalid type");
                return;
            }

            //input name
            Console.WriteLine("input the device name: ");
            string name = null;
            //invalid username
            while (name == null || name == "")
            {
                name = Console.ReadLine();
            }

            //create device
            Device newDevice = deviceRepo.Create(type, name);

            //if created failed, return to upper menu
            if (newDevice == null)
            {
                Console.WriteLine("Create {type} failed, please call Charles");
                return;
            }
            //add or replace the old one
            deviceRepo.Add(newDevice);
        }

        public void OperateDevice(Device device)
        {
            ////generate manual command
            //Command manualCommand = CommandFactory
            //    .CreateCommand(device.GetType().Name, "GetManual");

            ////if command not found, return upper menu
            //if (manualCommand == null)
            //{
            //    Console.WriteLine("\nget manual error, check name convention");
            //    return;
            //}
            //manualCommand.Receiver = device;
            var commands = CommandFactory
                .GetCommands(device.GetType().Name).ToList();
            commands.Add("Back");
            bool running = true;

            //operate device or return to upper menu
            do
            {
                //show options
                Console.WriteLine("\nplease select from following options:\n");
                //involker.SetCommand(manualCommand);
                //involker.ExecuteCommand();
                //show commands
                commands.ForEach(c => Console.WriteLine(c));
                Console.WriteLine("your choice is:");
                string choice = Console.ReadLine();

                //if "Back", back to upper menu
                if (choice == "Back")
                {
                    running = false;
                    continue;
                }
                //create command
                Command command = CommandFactory.CreateCommand(device.GetType().Name, choice);
                //if invalid command, restart
                if (command == null)
                {
                    Console.WriteLine("\ninvalid operation\n");
                    continue;
                }
                command.Receiver = device;

                //execute
                involker.SetCommand(command);
                involker.ExecuteCommand();

            } while (running);
        }

        public void RemoveDevice()
        {
            //if no device, back to upper menu
            if (!ShowDevices())
            {
                return;
            }

            //input device name
            Console.WriteLine("input the device name: ");
            string name = Console.ReadLine();

            //if not found, back to upper menu
            deviceRepo.Remove(name);

        }

        public void SelectDevice()
        {
            //if no device, back to upper menu
            if (!ShowDevices())
            {
                return;
            }

            //input device name
            Console.WriteLine("\ninput the device name: ");
            string name = Console.ReadLine();

            //get device, if not found, back to upper menu
            Device device = deviceRepo.Get(name);
            if (device == null)
            {
                Console.WriteLine("\ndevice {0} not found", name);
                return;
            }
            OperateDevice(device);
        }

        public bool ShowDevices()
        {
            //get devices name array
            var devices = deviceRepo.GetAll()
                .Select(x => x.Name)
                .ToArray();

            if(devices.Length == 0)
            {
                Console.WriteLine("\nno devices\n");
                return false;
            }
            else
            {
                Console.WriteLine("we have following devices");
                foreach(string name in devices)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine();
                return true;
            }

        }

        public void ShowMenu()
        {
            Console.WriteLine("please select one of the following options");
            foreach(string option in MENUOPTIONS)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine("\nselect:");
        }
    }
}
