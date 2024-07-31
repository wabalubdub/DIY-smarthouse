using Smarthouse.Backend.Models;
using Smarthouse.Backend.Services;
using System.Text.Json;

namespace Smarthouse.Backend.Commands
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
        int _percent;

        public DimmerCommand(ICommunicationService communicationService, Device device,  int percent){
            _communicationService = communicationService;
            _device = device;
            _percent = percent;
        }

        public override string GetBody()
        {
            DimmerRequest request = new DimmerRequest(_percent);
            return request.ToString();
        }
    }
}