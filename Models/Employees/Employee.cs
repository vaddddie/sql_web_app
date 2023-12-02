using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.Employees;

public class EmployeeModel : PageModel
{
    public required List<String[]> Rows;
    private readonly ILogger<EmployeeModel> _logger;

    public EmployeeModel(ILogger<EmployeeModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Rows = EmployeeSQL.List();
    }
}
