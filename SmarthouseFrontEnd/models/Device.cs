using System.Text.Json;

namespace smarthouse.Modles
{
    public abstract class Device{
        public  string Type { get; set; }
        public string Id{ get; set; }
        public string Name{ get; set; }
        public string IP{ get; set; }

        public override string ToString(){
            return JsonSerializer.Serialize<Device>(this);
        }

    }
}