using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.JobTitle;

public class JobTitleModel : PageModel
{
    public required List<String[]> Rows;
    private readonly ILogger<JobTitleModel> _logger;

    public JobTitleModel(ILogger<JobTitleModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Rows = JobTitleSQL.List();
    }
}
