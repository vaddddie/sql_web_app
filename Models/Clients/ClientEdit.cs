using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.Clients;

public class ClientEditModel : PageModel
{
    public required string[] Atributes;
    public required Dictionary<int, string> Locations;
    private readonly ILogger<ClientEditModel> _logger;

    public ClientEditModel(ILogger<ClientEditModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int id)
    {
        Atributes = ClientSQL.GetParamsById(id);
        Locations = ClientSQL.GetLocations();
    }

    public RedirectResult OnPostAccept(int id, string email, string fullname, string password, int location_id)
    {
        if (password != null)
        {
            ClientSQL.Update(id, email, fullname, HashClass.Hash(password), location_id);
        }
        else
        {
            ClientSQL.UpdateWithoutPassword(id, email, fullname, location_id);
        }

        return Redirect("/Clients");
    }

    public RedirectResult OnPostDelete(int id)
    {
        ClientSQL.Delete(id);
        return Redirect("/Clients");
    }
}