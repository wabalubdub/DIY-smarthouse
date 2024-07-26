using smarthouse.Modles;
using smarthouse.Services;
using System.Text.Json;

namespace smarthouse.Commands
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
        public CommunicationService _communicationService{ get; set; }
        public Device _device { get; set; }


        public OffCommand(CommunicationService communicationService, Device device){
            _communicationService = communicationService;
            _device = device;
        }

        public async Task Execute(){
            OnOffRequest request =  new OnOffRequest("off");
            await _communicationService.SendHttpGet(_device.IP,_device.Id, request.ToString());
        }

    }
}