namespace AwesomeAlgo;

public class StreamingAlgo
{
    public static async IAsyncEnumerable<string> MatchPairsUntilUpperBoundAsync(NumberNamePairManager pairManager, int upperBound)
    {
        if (upperBound < 0)
            throw new ArgumentException("Upper bound cannot be negative.");

        for (int i = 0; i < upperBound; i++)
        {
            var value = i + 1;
            string result = pairManager.GetNameForNumber(value);
            yield return result;

            // Simulate delay
            await Task.Delay(50); 
        }
    }
}
