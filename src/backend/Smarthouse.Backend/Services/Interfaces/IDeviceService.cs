using Smarthouse.Backend.Models;
using System.Text.Json;


namespace Smarthouse.Backend.Services
{
    public interface IDeviceService
    {

        public IEnumerable<Device> GetDevices();

        public Device GetDeviceByID(string id);
    }
}
