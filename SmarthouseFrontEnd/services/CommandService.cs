using System;
using System.Net.Http;
using System.Threading.Tasks;
using smarthouse.Commands;

namespace smarthouse.Services
{

    public class CommandService
    {
        public CommandService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public async void ExecuteCommand(ISmarthouseCommand command){
            await command.Execute();
        }
    }
}