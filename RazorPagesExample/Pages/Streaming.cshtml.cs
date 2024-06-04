using AwesomeAlgo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;

public class StreamingModel : PageModel
{
    [BindProperty]
    public int UpperBound { get; set; }

    [BindProperty]
    public List<int> Numbers { get; set; } = [];

    [BindProperty]
    public List<string> Names { get; set; } = [];

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            Response.ContentType = "text/event-stream";

            var pairManager = new NumberNamePairManager();
            for (int i = 0; i < Numbers.Count; i++)
            {
                pairManager.AddOrReplacePair(Numbers[i], Names[i]);
            }

            int position = 1;
            await foreach (var item in StreamingAlgo.MatchPairsUntilUpperBoundAsync(pairManager, UpperBound))
            {
                await Response.WriteAsync($"[{position}]: {item}\n\n");
                await Response.Body.FlushAsync();
                position++;
            }

            if (position == 1)
            {
                // This means UpperBound may have gone past Max Int Value
                await Response.WriteAsync($"UpperBound Value is 0. Max value that can be used is 2,147,483,647 Go back and try again.");
                await Response.Body.FlushAsync();
            }

            Response.Body.Close();
            return new EmptyResult();
        }
        catch (Exception ex)
        {
            // Log the exception details using ILogger and a logger provider instead of using Console.Writeline
            Console.WriteLine(ex);

            // Redirect to the generic error page
            return RedirectToPage("/Error");
        }
    }
}