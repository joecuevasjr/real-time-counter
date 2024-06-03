using AwesomeAlgo;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            var collection = new AwesomeAlgoClass();

            await foreach (var result in collection.CountToUpperBoundAsync(2147483647))
            {
                Console.WriteLine(result);
            }
        }
    }
}
