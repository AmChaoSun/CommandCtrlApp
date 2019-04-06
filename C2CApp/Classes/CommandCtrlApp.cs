using System;
using C2CApp.Classes.Commands;

namespace C2CApp.Classes
{
    public class CommandCtrlApp
    {
        private Command command;

        public void SetCommand(Command command)
        {
            this.command = command;
        }

        //public void ExcuteCommand()
        //{
        //    command.Excute();
        //}
    }
}
