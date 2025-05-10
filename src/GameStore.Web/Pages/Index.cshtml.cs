using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameStore.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        _logger.LogInformation("IndexModel initialized");
    }

    public void OnGet()
    {
        _logger.LogInformation("Home page visited at {Time}", DateTime.UtcNow);
    }
}
