using System;
using System.Threading.Tasks;
using Smarthouse.Backend.Commands;


namespace Smarthouse.Backend.Services
{
    public class CommandService : ICommandService
    {
        public CommandService()
        {

        }

        public async Task ExecuteCommand(ISmarthouseCommand command)
        {
            await command.Execute();

        }
    }
}