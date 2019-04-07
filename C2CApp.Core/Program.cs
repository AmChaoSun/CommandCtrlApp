using System;
using C2CApp.Core.Classes;

//this is for .net core version
namespace C2CApp.Core
{
    class Program
    {
        static void Main(string[] args)
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
