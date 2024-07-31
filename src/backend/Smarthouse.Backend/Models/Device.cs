using System.Text.Json;
using Smarthouse.Backend.Commands;
namespace Smarthouse.Backend.Models
{

    enum EDeviceType {
        Unknown,
        onoff,
        dimmer,

    }
    public class Device{
        public  string Type { get; set; }
        public string Id{ get; set; }
        public string Name{ get; set; }
        public string IP{ get; set; }

        private EDeviceType DeviceType { get; set; }

        public Device (string type, string id, string name, string ip)
        {
            if (type == null){throw new ArgumentNullException("type");}
            if (id == null){throw new ArgumentNullException("id");}
            if (name == null){throw new ArgumentNullException("name");}
            if (ip == null){throw new ArgumentNullException("ip");}
            Type = type;
            Id = id;
            Name = name;
            IP = ip;

            switch (Type) {
                case "switch":
                    DeviceType = EDeviceType.onoff;
                    break;
                case "dimmer":
                    DeviceType = EDeviceType.dimmer;
                    break;
                default:
                    DeviceType = EDeviceType.Unknown;
                    break;
            }
        }

        public override string ToString()=> JsonSerializer.Serialize<Device>(this); 
    }
}