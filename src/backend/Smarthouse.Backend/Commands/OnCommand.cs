using Smarthouse.Backend.Models;
using Smarthouse.Backend.Services;
using Smarthouse.Backend.Commands;
using System.Text.Json;

namespace Smarthouse.Backend.Commands
{

    public class OnCommand : ISmarthouseCommand
    {

        public OnCommand(ICommunicationService communicationService, Device device){
            _communicationService = communicationService;
            _device = device;
        }


        public override string GetBody(){
            OnOffRequest request =  new OnOffRequest("on");
            return request.ToString();            
        }


    }
}