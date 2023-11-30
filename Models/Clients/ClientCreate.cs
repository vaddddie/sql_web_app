using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;
using sql_web_app.Scripts;

namespace sql_web_app.Models.Clients;

public class ClientCreateModel : PageModel
{
    public required Dictionary<int, string> Locations;
    private readonly ILogger<ClientCreateModel> _logger;

    public ClientCreateModel(ILogger<ClientCreateModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Locations = ClientSQL.GetLocations();
    }

    public RedirectResult OnPost(string email, string fullname, string password, int location_id)
    {
        ClientSQL.Create(email, fullname, HashClass.Hash(password), location_id);

        return Redirect("/Clients");
    }
}
