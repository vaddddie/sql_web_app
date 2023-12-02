using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;
using sql_web_app.Scripts;

namespace sql_web_app.Models.ReportTypes;

public class ReportTypeCreateModel : PageModel
{
    private readonly ILogger<ReportTypeCreateModel> _logger;

    public ReportTypeCreateModel(ILogger<ReportTypeCreateModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public RedirectResult OnPost(string title)
    {
        ReportTypeSQL.Create(title);
        return Redirect("/ReportTypes");
    }
}
