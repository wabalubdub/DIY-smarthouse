
public abstract class abstractControler
{
    // Abstract method
    public abstract void envoke_controler();
    
    public string device_name { get; set; }

    public string controler_name { get; set; }

    // Concrete method
    public void DisplayInfo()
    {
        Console.WriteLine($"This is a {GetType().Name}");
    }

    // Concrete property
}

public class light_controler : abstractControler
{
    private bool isOn; // Variable representing the state of the switch

    // Getter method to get the current state of the switch
    public bool IsOn()
    {
        return isOn;
    }

    // Setter method to change the state of the switch to "on"
    public virtual void TurnOn()
    {
        //turn off  logic here
    }

    // Setter method to change the state of the switch to "off"
    public virtual void TurnOff()
    {
        //turn off  logic here
    }

    // Method to toggle the state of the switch (if it's on, turn it off; if it's off, turn it on)
    public void Toggle()
    {
        isOn = !isOn;
    }

    // Constructor
    public light_controler(bool initialState, string device_name, string controler_name)
    {
        isOn = initialState;
        this.device_name = device_name;
        this.controler_name = controler_name;
    }

    // Implementation of abstract method
    public override void envoke_controler()
    {
        this.Toggle();
        if (isOn){
            this.TurnOff();
        }
        else{
            this.TurnOn();
        }
    }
}

public class LED_controler :light_controler{
    // Constructor and invoke is inherited from light_controler

    public LED_controler(bool initialState, string device_name, string controler_name) : base(initialState,device_name,controler_name)
    {

    }
    public void start_up_sequence(){
        //insert logic here
    }

    public void shut_down_sequence()
    {
        //insert logic here
    }

    public void on_state(){
        throw new ArgumentException("method not impemented.");

    }

    // Method overriding the on and off  from the light_controler
    public override void TurnOff()
    {
        this.shut_down_sequence();
    }
    public override void TurnOn()
    {
        this.start_up_sequence();
        this.on_state();
    }
}

public class controlerFactory
{
    public abstractControler CreateProduct(string type, string device_name, string controler_name)
    {
        switch (type)
        {
            case "Led":
                return new LED_controler(false, device_name, controler_name);
            default:
                throw new ArgumentException("Invalid controller type.");
        }
    }
}

