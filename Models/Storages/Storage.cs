using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_web_app.Scripts.Tables;


namespace sql_web_app.Models.Storages;

public class StorageModel : PageModel
{
    public required List<String[]> Rows;
    private readonly ILogger<StorageModel> _logger;

    public StorageModel(ILogger<StorageModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Rows = StorageSQL.List();
    }
}
