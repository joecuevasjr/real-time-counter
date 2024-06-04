namespace AwesomeAlgo.Tests;

public class NumberNamePairTests
{
    [Fact]
    public void Constructor_ValidInputs_SetsPropertiesCorrectly()
    {
        // Arrange
        int number = 5;
        string name = "Cuevas";

        // Act
        var pair = new NumberNamePair(number, name);

        // Assert
        Assert.Equal(number, pair.Number);
        Assert.Equal(name, pair.Name);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_NumberOutOfRange_ThrowsArgumentOutOfRangeException(int number)
    {
        // Arrange
        string name = "Joe";

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new NumberNamePair(number, name));
        Assert.Contains("Number must be between 1 and Int32.MaxValue", exception.Message);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void Constructor_NullOrWhiteSpaceName_ThrowsArgumentException(string name)
    {
        // Arrange
        int number = 5;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new NumberNamePair(number, name));
        Assert.Contains("Name cannot be null or whitespace", exception.Message);
    }

    [Theory]
    [InlineData("Joe1")]
    [InlineData("Joe!")]
    [InlineData("Joe-Cuevas")]
    public void Constructor_InvalidNameCharacters_ThrowsArgumentException(string name)
    {
        // Arrange
        int number = 3;

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => new NumberNamePair(number, name));
        Assert.Contains("Name must only contain alphabetical characters", ex.Message);
    }
}