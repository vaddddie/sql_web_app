using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts;
using MySqlConnector;
using sql_web_app.Scripts.Tables;

namespace sql_web_app.Models;

public class IndexModel : PageModel
{
    public required int ClientCount;
    public required int OrderCount;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        ClientCount = ClientSQL.Count();
        OrderCount = OrderSQL.Count();
    }
}
