using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;
using sql_web_app.Scripts;

namespace sql_web_app.Models.Orders;

public class OrderCreateModel : PageModel
{
    public required Dictionary<int, string> Clients;
    public required Dictionary<int, string> Tariffs;
    private readonly ILogger<OrderCreateModel> _logger;

    public OrderCreateModel(ILogger<OrderCreateModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Clients = OrderSQL.GetClients();
        Tariffs = OrderSQL.GetTariffs();
    }

    public RedirectResult OnPost(int client_id, int tariff_id, DateTime dateTime)
    {
        OrderSQL.Create(client_id, tariff_id, dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        return Redirect("/Orders");
    }
}
