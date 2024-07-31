using Smarthouse.Backend.Models;
using Smarthouse.Backend.Services;

namespace Smarthouse.Backend.Commands
{
    public abstract class ISmarthouseCommand
    {
        public ICommunicationService _communicationService{ get; set; }
        public Device _device { get; set; }

        public void Configure() //template method design pattern 
        {
            if (_communicationService is HttpGetCommunicationService httpGetCommunicationService)
            {
                httpGetCommunicationService.SetIPAddress(_device.IP);
                httpGetCommunicationService.SetPort("8080");
                httpGetCommunicationService.SetRoute(_device.Id);
                httpGetCommunicationService.SetRequestBody(this.GetBody());
            }

        }

        public virtual string GetBody(){
            return null;
        }
        public virtual async Task Execute(){
            this.Configure();
            await _communicationService.Send();

        }
    }
}