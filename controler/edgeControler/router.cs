
using System.Collections.Generic;

using System.Net;

using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Router{
    
    private Dictionary<string, System.Net.IPAddress> IP_cache = new Dictionary<string, System.Net.IPAddress>();
    private Dictionary<string, string> router_cache = new Dictionary<string, string>();


    public Router (){

    }

    public void add_device_IP(string device_name, System.Net.IPAddress IP ){
        IP_cache[device_name]= IP;
    }

    public void send_request(string device_name, string controler_name, string json ){
        if(IP_cache.ContainsKey(device_name)){
            IPAddress device_IP = this.get_IP(device_name);
            add_device_IP(device_name,device_IP);
        }
        IPAddress device_IP_to_send = this.IP_cache[device_name];
        this.send_put(device_IP_to_send, "80", controler_name, json);
    }

    public async Task send_put( IPAddress device_IP_to_send, string PORT, string route, string json){
        string url = $"http://{device_IP_to_send}:{PORT}/{route}";
        using (HttpClient client = new HttpClient())
        {
            // Create HTTP request content (if needed)
            // For example, if you want to send JSON data in the request body:
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Create and send PUT request
            HttpResponseMessage response = await client.PutAsync(url, content); // Pass content if needed

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("PUT request successful");
            }
            else
            {
                Console.WriteLine($"PUT request failed with status code {response.StatusCode}");
            }
        }
    }

    public System.Net.IPAddress get_IP(string device_name ){
        
        string ipv4String = "192.168.1.1";
        IPAddress ipAddressV4 = IPAddress.Parse(ipv4String);
        return ipAddressV4;

    }
}