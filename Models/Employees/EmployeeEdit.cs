using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.Employees;

public class EmployeeEditModel : PageModel
{
    public required string[] Atributes;
    public required Dictionary<int, string> JobTitles;
    public required List<string> Emails;
    private readonly ILogger<EmployeeEditModel> _logger;

    public EmployeeEditModel(ILogger<EmployeeEditModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int id)
    {
        Atributes = EmployeeSQL.GetParamsById(id);
        JobTitles = EmployeeSQL.GetJobTitles();
        Emails = EmployeeSQL.GetEmails();
    }

    public RedirectResult OnPostAccept(int id, int jobTitle_id, string email, string fullname, string password, int rate)
    {
        if (password != null)
        {
            EmployeeSQL.Update(id, jobTitle_id, email, fullname, HashClass.Hash(password), rate);
        }
        else
        {
            EmployeeSQL.UpdateWithoutPassword(id, jobTitle_id, email, fullname, rate);
        }

        return Redirect("/Employees");
    }

    public RedirectResult OnPostDelete(int id)
    {
        EmployeeSQL.Delete(id);
        return Redirect("/Employees");
    }
}