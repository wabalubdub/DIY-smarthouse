using Smarthouse.Backend.Models;
using System.Text.Json;


namespace Smarthouse.Backend.Services
{
    public class JsonFileDeviceService: IDeviceService
    {
        public JsonFileDeviceService(string JsonFileName)
        {
            _JsonFileName = JsonFileName;
        }


        private string _JsonFileName{get;set;} 

        public IEnumerable<Device> GetDevices()
        {
            using var jsonFileReader = File.OpenText(_JsonFileName);
            Device[]? devices = JsonSerializer.Deserialize<Device[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (devices == null){
                    return Enumerable.Empty<Device>();
                }
                return devices;
        }

        public Device GetDeviceByID(string id)
        {
            return this.GetDevices().First(x => x.Id == id);
        }
        
    }
}