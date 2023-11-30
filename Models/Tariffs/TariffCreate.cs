using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;
using sql_web_app.Scripts;

namespace sql_web_app.Models.Tariffs;

public class TariffCreateModel : PageModel
{
    private readonly ILogger<TariffCreateModel> _logger;

    public TariffCreateModel(ILogger<TariffCreateModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public RedirectResult OnPost(int memory, string price)
    {
        TariffSQL.Create(memory, price);
        return Redirect("/Tariffs");
    }
}
