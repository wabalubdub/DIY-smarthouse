using smarthouse.Modles;
using smarthouse.Services;
using System.Text.Json;

namespace smarthouse.Commands
{
    public class DimmerRequest{
        public string commandType { get=> "dimmer";}
        public int percent { get; set;}

        public DimmerRequest(int percent){
            this.percent = percent;

        }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }

    public class DimmerCommand : ISmarthouseCommand
    {
        public CommunicationService _communicationService{ get; set; }
        public Device _device { get; set; }
        int _percent;


        public DimmerCommand(CommunicationService communicationService, Device device,  int percent){
            _communicationService = communicationService;
            _device = device;
            _percent = percent;
        }

        public void Execute(){
            _communicationService.SendHttpGet(_device.IP,_device.Id, new DimmerRequest(_percent).ToString() );
        }

    }
}