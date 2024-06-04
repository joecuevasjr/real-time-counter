using AwesomeAlgo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;

public class StreamingModel : PageModel
{
    private readonly StreamingAlgo _streamer;

    public int? UpperBound { get; private set; }

    public StreamingModel()
    {
        _streamer = new StreamingAlgo();
    }

    public void OnGet(int? upperBound)
    {
        UpperBound = upperBound;
    }

    public IActionResult OnPost(int upperBound)
    {
        return RedirectToPage(new { upperBound }); // Redirect with upperBound as a query parameter
    }

    public async Task<IActionResult> OnGetStreamNumbers(int upperBound)
    {
        Response.ContentType = "text/event-stream";

        var pairManager = new NumberNamePairManager();
        pairManager.AddOrReplacePair(3, "Joe");
        pairManager.AddOrReplacePair(5, "Cuevas");
        pairManager.AddOrReplacePair(7, "Steve");
        pairManager.AddOrReplacePair(20, "Sanderson");
        pairManager.AddOrReplacePair(50, "Dan");
        pairManager.AddOrReplacePair(100, "Roth");
        pairManager.AddOrReplacePair(3, "Jose");

        var position = 1;
        await foreach (var number in StreamingAlgo.MatchPairsUntilUpperBoundAsync(pairManager, upperBound))
        {
            await Response.WriteAsync($"data:[{position}]: {number}\n\n");
            await Response.Body.FlushAsync();
            position++;
        }

        return new EmptyResult();
    }
}