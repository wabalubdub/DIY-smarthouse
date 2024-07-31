using Smarthouse.Backend.Models;
using Smarthouse.Backend.Services;
using System.Text.Json;


namespace Smarthouse.frontend.Services
{
    public class DeviceServiceWrapper
    {
        private ILogger<DeviceServiceWrapper> _logger;
        private  IDeviceService _deviceService;
        public DeviceServiceWrapper(IWebHostEnvironment webHostEnvironment, ILogger<DeviceServiceWrapper> logger)
        {
            WebHostEnvironment = webHostEnvironment;
            _logger = logger;
            _deviceService = new JsonFileDeviceService(Path.Combine(WebHostEnvironment.WebRootPath, "data", "devices.json"));
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "devices.json");

        public IEnumerable<Device> GetDevices()
        {
            Console.WriteLine(JsonFileName);  
            return _deviceService.GetDevices();
         }

        public Device GetDeviceByID(string id)
        {
             return _deviceService.GetDeviceByID(id);
        }
        
    }
}