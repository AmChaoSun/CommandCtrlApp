using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using C2CApp.Classes;
using C2CApp.Classes.Channels;
using C2CApp.Classes.Devices;
using C2CApp.Classes.Devices.Abstractions;

namespace C2CApp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C2C!");

            bool running = true;
            var app = CommandCtrlApp.Instance;
            while (running)
            {
                app.ShowMenu();
                string operation = Console.ReadLine();
                switch (operation)
                {
                    case "select device": app.SelectDevice(); break;
                    case "add device": app.AddDevice(); break;
                    case "remove device": app.RemoveDevice(); break;
                    case "exit":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("invalid operation");
                        Console.WriteLine();
                        break;
                }
            }


        }
    }
}
