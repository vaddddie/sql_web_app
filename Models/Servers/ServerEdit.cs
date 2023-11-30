using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.Servers;

public class ServerEditModel : PageModel
{
    public required string[] Atributes;
    private readonly ILogger<ServerEditModel> _logger;

    public ServerEditModel(ILogger<ServerEditModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int id)
    {
        Atributes = ServerSQL.GetParamsById(id);
    }

    public RedirectResult OnPostAccept(int id, string location, int memory, int status)
    {
        ServerSQL.Update(id, location, memory, status);
        return Redirect("/Servers");
    }

    public RedirectResult OnPostDelete(int id)
    {
        ServerSQL.Delete(id);
        return Redirect("/Servers");
    }
}