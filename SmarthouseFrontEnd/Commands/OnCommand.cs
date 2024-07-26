using smarthouse.Modles;
using smarthouse.Services;
using smarthouse.Commands;
using System.Text.Json;

namespace smarthouse.Commands
{

    public class OnCommand : ISmarthouseCommand
    {
        public CommunicationService _communicationService{ get; set; }
        public Device _device { get; set; }


        public OnCommand(CommunicationService communicationService, Device device){
            _communicationService = communicationService;
            _device = device;
        }

        public void Execute(){
            OnOffRequest request =  new OnOffRequest("on");
            _communicationService.SendHttpGet(_device.IP,_device.Id,request.ToString());
        }

    }
}