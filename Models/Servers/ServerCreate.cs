using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;
using sql_web_app.Scripts;

namespace sql_web_app.Models.Servers;

public class ServerCreateModel : PageModel
{
    private readonly ILogger<ServerCreateModel> _logger;

    public ServerCreateModel(ILogger<ServerCreateModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public RedirectResult OnPost(string location, int memory, int status)
    {
        ServerSQL.Create(location, memory, status);
        return Redirect("/Servers");
    }
}
