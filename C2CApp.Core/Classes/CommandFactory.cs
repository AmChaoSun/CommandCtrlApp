using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using C2CApp.Core.Classes.Commands;


namespace C2CApp.Core.Classes
{
    public static class CommandFactory
    {
        private const string ASSEMBLY = "C2CApp.Core";
        private const string COMMANDNS = "C2CApp.Core.Classes.Commands";

        public static Command CreateCommand(string type, string operation)
        {
            string instanceName = String.Format("{0}.{1}Commands.{2}",
                COMMANDNS, type, operation);

            //create and return device
            return (Command)Assembly.Load(ASSEMBLY)
                .CreateInstance(instanceName);
        }

        public static IEnumerable<string> GetCommands(string type)
        {
            string ns = String.Format("{0}.{1}Commands", COMMANDNS, type);
            var commands = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == ns
                    select t.Name;
            return commands;
        }
    }
}
