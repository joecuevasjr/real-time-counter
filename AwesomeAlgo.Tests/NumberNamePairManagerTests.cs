namespace AwesomeAlgo.Tests;

public class NumberNamePairManagerTests
{
    [Fact]
    public void AddOrReplacePair_ValidInput_AddsNewPair()
    {
        // Arrange
        var manager = new NumberNamePairManager();
        int number = 3;
        string name = "Joe";

        // Act
        manager.AddOrReplacePair(number, name);

        // Assert
        Assert.Equal("Joe", manager.GetNameForNumber(3));
    }

    [Fact]
    public void AddOrReplacePair_ReplaceExistingPair_UpdatesPair()
    {
        // Arrange
        var manager = new NumberNamePairManager();
        manager.AddOrReplacePair(3, "Joe");

        // Act
        manager.AddOrReplacePair(3, "Jose");

        // Assert
        Assert.Equal("Jose", manager.GetNameForNumber(3));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void AddOrReplacePair_InvalidNumber_ThrowsArgumentOutOfRangeException(int number)
    {
        // Arrange
        var manager = new NumberNamePairManager();
        string name = "Joe";

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => manager.AddOrReplacePair(number, name));
        Assert.Contains("Number must be positive and greater than zero", ex.Message);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void AddOrReplacePair_InvalidName_ThrowsArgumentException(string name)
    {
        // Arrange
        var manager = new NumberNamePairManager();
        int number = 3;

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => manager.AddOrReplacePair(number, name));
        Assert.Contains("Name cannot be null or whitespace", ex.Message);
    }

    [Fact]
    public void GetNameForNumber_ValidNumber_ReturnsName()
    {
        // Arrange
        var manager = new NumberNamePairManager();
        manager.AddOrReplacePair(3, "Joe");
        manager.AddOrReplacePair(5, "Cuevas");

        // Act
        string result = manager.GetNameForNumber(15);

        // Assert
        Assert.Equal("Joe Cuevas", result);
    }

    [Fact]
    public void GetNameForNumber_NumberNotDivisible_ReturnsNumberAsString()
    {
        // Arrange
        var manager = new NumberNamePairManager();
        manager.AddOrReplacePair(3, "Joe");
        manager.AddOrReplacePair(5, "Cuevas");

        // Act
        string result = manager.GetNameForNumber(7);

        // Assert
        Assert.Equal("7", result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void GetNameForNumber_InvalidNumber_ThrowsArgumentOutOfRangeException(int number)
    {
        // Arrange
        var manager = new NumberNamePairManager();

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => manager.GetNameForNumber(number));
        Assert.Contains("Number must be positive and greater than zero", ex.Message);
    }

    [Fact]
    public void GetNameForNumber_CompositeNumberWithReplacements_ReturnsExpectedResult()
    {
        // Arrange
        var pairManager = new NumberNamePairManager();
        pairManager.AddOrReplacePair(2, "Joe");
        pairManager.AddOrReplacePair(5, "Cuevas");
        pairManager.AddOrReplacePair(7, "Steve");
        pairManager.AddOrReplacePair(20, "Sanderson");
        pairManager.AddOrReplacePair(50, "Dan");
        pairManager.AddOrReplacePair(100, "Roth");
        // Replacing a previously added pair
        pairManager.AddOrReplacePair(2, "Jose");

        // Act
        string result = pairManager.GetNameForNumber(100);

        // Assert
        Assert.Equal("Jose Cuevas Sanderson Dan Roth", result);
    }
}
