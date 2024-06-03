using AwesomeAlgo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;

public class StreamingModel : PageModel
{
    private readonly AwesomeAlgoClass _streamer;

    public int? UpperBound { get; private set; }

    public StreamingModel()
    {
        _streamer = new AwesomeAlgoClass();
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

        await foreach (var number in AwesomeAlgoClass.CountToUpperBoundAsync(upperBound))
        {
            await Response.WriteAsync($"data: {number}\n\n");
            await Response.Body.FlushAsync();
        }

        return new EmptyResult();
    }
}