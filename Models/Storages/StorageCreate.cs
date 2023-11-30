using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;
using sql_web_app.Scripts;

namespace sql_web_app.Models.Storages;

public class StorageCreateModel : PageModel
{
    public required Dictionary<int, string> Clients;
    public required Dictionary<int, string> Locations;
    private readonly ILogger<StorageCreateModel> _logger;

    public StorageCreateModel(ILogger<StorageCreateModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Clients = StorageSQL.GetClients();
        Locations = StorageSQL.GetLocations();
    }

    public RedirectResult OnPost(int client_id, int memory, int server_id, DateTime endDatetime)
    {
        StorageSQL.Create(client_id, memory, server_id, endDatetime.ToString("yyyy-MM-dd HH:mm:ss"));

        return Redirect("/Storages");
    }
}
