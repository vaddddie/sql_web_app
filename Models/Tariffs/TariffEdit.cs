using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.Tariffs;

public class TariffEditModel : PageModel
{
    public required string[] Atributes;
    private readonly ILogger<TariffEditModel> _logger;

    public TariffEditModel(ILogger<TariffEditModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int id)
    {
        Atributes = TariffSQL.GetParamsById(id);
    }

    public RedirectResult OnPostAccept(int id, int memory, string price)
    {
        TariffSQL.Update(id, memory, price);
        return Redirect("/Tariffs");
    }

    public RedirectResult OnPostDelete(int id)
    {
        TariffSQL.Delete(id);
        return Redirect("/Tariffs");
    }
}