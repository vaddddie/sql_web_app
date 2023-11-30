using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.Servers;

public class ServerModel : PageModel
{
    public required List<String[]> Rows;
    private readonly ILogger<ServerModel> _logger;

    public ServerModel(ILogger<ServerModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Rows = ServerSQL.List();
    }
}
