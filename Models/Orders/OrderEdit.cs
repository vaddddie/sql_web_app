using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.Orders;

public class OrderEditModel : PageModel
{
    public required string[] Atributes;
    public required Dictionary<int, string> Clients;
    public required Dictionary<int, string> Tariffs;
    private readonly ILogger<OrderEditModel> _logger;

    public OrderEditModel(ILogger<OrderEditModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int id)
    {
        Atributes = OrderSQL.GetParamsById(id);
        Clients = OrderSQL.GetClients();
        Tariffs = OrderSQL.GetTariffs();
    }

    public RedirectResult OnPostAccept(int id, int client_id, int tariff_id, DateTime dateTime)
    {
        OrderSQL.Update(id, client_id, tariff_id, dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        return Redirect("/Orders");
    }

    public RedirectResult OnPostDelete(int id)
    {
        OrderSQL.Delete(id);
        return Redirect("/Orders");
    }
}