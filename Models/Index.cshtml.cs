using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts;
using MySqlConnector;
using sql_web_app.Scripts.Tables;

namespace sql_web_app.Models;

public class IndexModel : PageModel
{
    public required int OrderCount;
    public required int ClientCount;
    public required int EmployeeCount;
    public required int UnsolvedReportCount;

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        OrderCount = OrderSQL.Count();
        ClientCount = ClientSQL.Count();
        EmployeeCount = EmployeeSQL.Count();
        UnsolvedReportCount = ReportSQL.CountUnsolved();
    }
}
