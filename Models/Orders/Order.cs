using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.Orders;

public class OrderModel : PageModel
{
    public required List<String[]> Rows;
    private readonly ILogger<OrderModel> _logger;

    public OrderModel(ILogger<OrderModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Rows = OrderSQL.List();
    }
}
