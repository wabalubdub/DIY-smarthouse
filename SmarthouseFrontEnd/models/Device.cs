using System.Text.Json;

namespace smarthouse.Modles
{
    public class Device{
        public  string Type { get; set; }
        public string Id{ get; set; }
        public string Name{ get; set; }
        public string IP{ get; set; }

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
        }

        public override string ToString()=> JsonSerializer.Serialize<Device>(this); 

    }
}