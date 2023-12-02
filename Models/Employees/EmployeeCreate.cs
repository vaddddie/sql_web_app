using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;
using sql_web_app.Scripts;

namespace sql_web_app.Models.Employees;

public class EmployeeCreateModel : PageModel
{
    public required Dictionary<int, string> JobTitles;
    private readonly ILogger<EmployeeCreateModel> _logger;

    public EmployeeCreateModel(ILogger<EmployeeCreateModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        JobTitles = EmployeeSQL.GetJobTitles();
    }

    public RedirectResult OnPost(int jobTitle_id, string email, string fullname, string password)
    {
        EmployeeSQL.Create(jobTitle_id, email, fullname, HashClass.Hash(password));
        return Redirect("/Employees");
    }
}
