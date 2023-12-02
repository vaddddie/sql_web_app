using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;
using sql_web_app.Scripts;

namespace sql_web_app.Models.Reports;

public class ReportCreateModel : PageModel
{
    public required Dictionary<int, string> Clients;
    public required Dictionary<int, string> ReportTypes;
    public required Dictionary<int, string> Employees;
    private readonly ILogger<ReportCreateModel> _logger;

    public ReportCreateModel(ILogger<ReportCreateModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Clients = ReportSQL.GetClients();
        ReportTypes = ReportSQL.GetReportTypes();
        Employees = ReportSQL.GetEmployees();
    }

    public RedirectResult OnPost(int client_id, int reportType_id, int employee_id, int status)
    {
        ReportSQL.Create(client_id, reportType_id, employee_id, status);
        return Redirect("/Reports");
    }
}
