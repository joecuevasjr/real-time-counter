namespace AwesomeAlgo;

/// <summary>
/// Provides functionality to stream number-name pairs up to an upper bound.
/// </summary>
public class StreamingAlgo
{
    /// <summary>
    /// Asynchronously streams number-name pairs based on divisibility up to the specified upper bound.
    /// </summary>
    /// <param name="pairManager">The manager containing the number-name pairs.</param>
    /// <param name="upperBound">The upper limit for the numbers to be checked. Must be non-negative.</param>
    /// <returns>An asynchronous enumerable of strings representing the names or numbers.</returns>
    /// <exception cref="ArgumentException">Thrown when the upper bound is negative.</exception>
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
