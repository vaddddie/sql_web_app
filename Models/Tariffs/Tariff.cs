using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.Tariffs;

public class TariffModel : PageModel
{
    public required List<String[]> Rows;
    private readonly ILogger<TariffModel> _logger;

    public TariffModel(ILogger<TariffModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Rows = TariffSQL.List();
    }
}
