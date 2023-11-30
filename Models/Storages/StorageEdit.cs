using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.Storages;

public class StorageEditModel : PageModel
{
    public required string[] Atributes;
    public required Dictionary<int, string> Clients;
    public required Dictionary<int, string> Locations;
    private readonly ILogger<StorageEditModel> _logger;

    public StorageEditModel(ILogger<StorageEditModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int id)
    {
        Atributes = StorageSQL.GetParamsById(id);
        Clients = StorageSQL.GetClients();
        Locations = StorageSQL.GetLocations();
    }

    public RedirectResult OnPostAccept(int id, int client_id, int memory, int server_id, DateTime endDatetime)
    {
        StorageSQL.Update(id, client_id, memory, server_id, endDatetime.ToString("yyyy-MM-dd HH:mm:ss"));
        return Redirect("/Storages");
    }

    public RedirectResult OnPostDelete(int id)
    {
        StorageSQL.Delete(id);
        return Redirect("/Storages");
    }
}