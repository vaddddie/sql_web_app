using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.Reports;

public class ReportModel : PageModel
{
    public required List<String[]> Rows;
    private readonly ILogger<ReportModel> _logger;

    public ReportModel(ILogger<ReportModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Rows = ReportSQL.List();
    }
}
