using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.Clients;

public class ClientModel : PageModel
{
    public required List<String[]> Rows;
    private readonly ILogger<ClientModel> _logger;

    public ClientModel(ILogger<ClientModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Rows = ClientSQL.List();
    }
}
