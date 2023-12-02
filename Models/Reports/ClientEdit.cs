using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.Reports;

public class ReportEditModel : PageModel
{
    public required string[] Atributes;
    public required Dictionary<int, string> Clients;
    public required Dictionary<int, string> ReportTypes;
    public required Dictionary<int, string> Employees;
    private readonly ILogger<ReportEditModel> _logger;

    public ReportEditModel(ILogger<ReportEditModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int id)
    {
        Atributes = ReportSQL.GetParamsById(id);
        Clients = ReportSQL.GetClients();
        ReportTypes = ReportSQL.GetReportTypes();
        Employees = ReportSQL.GetEmployees();
    }

    public RedirectResult OnPostAccept(int id, int client_id, int reportType_id, int employee_id, int status)
    {
        ReportSQL.Update(id, client_id, reportType_id, employee_id, status);
        return Redirect("/Reports");
    }

    public RedirectResult OnPostDelete(int id)
    {
        ReportSQL.Delete(id);
        return Redirect("/Reports");
    }
}