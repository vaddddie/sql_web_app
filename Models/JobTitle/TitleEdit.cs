using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.JobTitle;

public class JobTitleEditModel : PageModel
{
    public required string[] Atributes;
    private readonly ILogger<JobTitleEditModel> _logger;

    public JobTitleEditModel(ILogger<JobTitleEditModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int id)
    {
        Atributes = JobTitleSQL.GetParamsById(id);
    }

    public RedirectResult OnPostAccept(int id, string title, int accessLevel)
    {
        JobTitleSQL.Update(id, title, accessLevel);
        return Redirect("/JobTitles");
    }

    public RedirectResult OnPostDelete(int id)
    {
        JobTitleSQL.Delete(id);
        return Redirect("/JobTitles");
    }
}