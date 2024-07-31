using System;
using System.Threading.Tasks;
using Smarthouse.Backend.Commands;


namespace Smarthouse.Backend.Services
{
    public interface ICommandService
    {

        public Task ExecuteCommand (ISmarthouseCommand command);
    }
}