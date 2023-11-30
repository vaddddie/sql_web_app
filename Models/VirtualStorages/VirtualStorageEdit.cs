using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.VirtualStorages;

public class VirtualStorageEditModel : PageModel
{
    public required string[] atributes;
    private readonly ILogger<VirtualStorageEditModel> _logger;

    public VirtualStorageEditModel(ILogger<VirtualStorageEditModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int id)
    {
        atributes = VirtualStorageSQL.GetParamsById(id);
    }

    public RedirectResult OnPostAccept(int id, string username, string password)
    {
        VirtualStorageSQL.Update(id, username, password);

        return Redirect("/VirtualStorages");
    }
}