using System;
using System.Reflection;
using C2CApp.Classes.Commands;


namespace C2CApp.Classes
{
    public static class CommandFactory
    {
        const string ASSEMBLY = "C2CApp";
        const string COMMANDNS = "C2CApp.Classes.Commands";

        public static Command CreateCommand(string type, string operation)
        {
            string instanceName = String.Format("{0}.{1}Commands.{2}",
                COMMANDNS, type, operation);

            //create and return device
            return (Command)Assembly.Load(ASSEMBLY)
                .CreateInstance(instanceName);
        }
    }
}
