using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.ReportTypes;

public class ReportTypeModel : PageModel
{
    public required List<String[]> Rows;
    private readonly ILogger<ReportTypeModel> _logger;

    public ReportTypeModel(ILogger<ReportTypeModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Rows = ReportTypeSQL.List();
    }
}
