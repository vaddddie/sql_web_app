using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.ReportTypes;

public class ReportTypeEditModel : PageModel
{
    public required string[] Atributes;
    private readonly ILogger<ReportTypeEditModel> _logger;

    public ReportTypeEditModel(ILogger<ReportTypeEditModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int id)
    {
        Atributes = ReportTypeSQL.GetParamsById(id);
    }

    public RedirectResult OnPostAccept(int id, string title)
    {
        ReportTypeSQL.Update(id, title);
        return Redirect("/ReportTypes");
    }

    public RedirectResult OnPostDelete(int id)
    {
        ReportTypeSQL.Delete(id);
        return Redirect("/ReportTypes");
    }
}