using smarthouse.Modles;
using System.Text.Json;


namespace smarthouse.Services
{
    public class DeviceService
    {
        public DeviceService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "devices.json");

        public IEnumerable<Device> GetDevices()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
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