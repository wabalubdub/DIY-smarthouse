using Smarthouse.Backend.Models;
using Smarthouse.Backend.Services;
using System.Text.Json;

namespace Smarthouse.Backend.Commands
{

    public class OnOffRequest{
        public string commandType { get=> "onoff";}
        public string state { get; set;}

        public OnOffRequest(string state){
            this.state = state;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
    public class OffCommand : ISmarthouseCommand
    {

        public OffCommand(ICommunicationService communicationService, Device device){
            _communicationService = communicationService;
            _device = device;
        }
        public override string GetBody(){
            OnOffRequest request =  new OnOffRequest("off");
            return request.ToString();
        }


    }
}