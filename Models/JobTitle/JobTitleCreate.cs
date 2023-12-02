using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;
using sql_web_app.Scripts;

namespace sql_web_app.Models.JobTitle;

public class JobTitleCreateModel : PageModel
{
    private readonly ILogger<JobTitleCreateModel> _logger;

    public JobTitleCreateModel(ILogger<JobTitleCreateModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public RedirectResult OnPost(string title, int accessLevel)
    {
        JobTitleSQL.Create(title, accessLevel);
        return Redirect("/JobTitles");
    }
}
