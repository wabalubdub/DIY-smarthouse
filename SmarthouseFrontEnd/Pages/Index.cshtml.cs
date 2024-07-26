using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using smarthouse.Modles;
using smarthouse.Services;

namespace SmarthouseFrontEnd.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public DeviceService _deviceService;
    public IEnumerable<Device>? devices;

    public IndexModel(ILogger<IndexModel> logger, DeviceService deviceService)
    {
        _logger = logger;
        _deviceService = deviceService;
    }

    public void OnGet()
    {
        devices = _deviceService.GetDevices();
    }
}
