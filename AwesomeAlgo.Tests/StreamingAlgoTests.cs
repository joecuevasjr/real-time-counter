namespace AwesomeAlgo.Tests;

public class StreamingAlgoTests
{
    // Helper method to collect IAsyncEnumerable results into a list
    private static async Task<List<T>> CollectAsync<T>(IAsyncEnumerable<T> asyncEnumerable)
    {
        var results = new List<T>();
        await foreach (var item in asyncEnumerable)
        {
            results.Add(item);
        }
        return results;
    }

    [Fact]
    public async Task MatchPairsUntilUpperBoundAsync_NegativeUpperBound_ThrowsArgumentException()
    {
        // Arrange
        var pairManager = new NumberNamePairManager();

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(
            () => CollectAsync(StreamingAlgo.MatchPairsUntilUpperBoundAsync(pairManager, -1))
        );
        Assert.Contains("Upper bound cannot be negative.", exception.Message);
    }

    [Fact]
    public async Task MatchPairsUntilUpperBoundAsync_ValidInput_YieldsCorrectResults()
    {
        // Arrange
        var pairManager = new NumberNamePairManager();
        pairManager.AddOrReplacePair(2, "Joe");
        pairManager.AddOrReplacePair(3, "Cuevas");

        // Act
        var results = await CollectAsync(StreamingAlgo.MatchPairsUntilUpperBoundAsync(pairManager, 3));

        // Assert
        Assert.Collection(results,
            result => Assert.Equal("1", result),  // Ungregistered pair, returns "1"
            result => Assert.Equal("Joe", result),  // For 2
            result => Assert.Equal("Cuevas", result));  // For 3
    }

    [Fact]
    public async Task MatchPairsUntilUpperBoundAsync_ZeroUpperBound_YieldsNoResults()
    {
        // Arrange
        var pairManager = new NumberNamePairManager();

        // Act
        var results = await CollectAsync(StreamingAlgo.MatchPairsUntilUpperBoundAsync(pairManager, 0));

        // Assert
        Assert.Empty(results);
    }
}
