using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.VirtualStorages;

public class VirtualStorageModel : PageModel
{
    public required List<String[]> Rows;
    private readonly ILogger<VirtualStorageModel> _logger;

    public VirtualStorageModel(ILogger<VirtualStorageModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Rows = VirtualStorageSQL.List();
    }
}
