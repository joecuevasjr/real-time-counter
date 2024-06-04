namespace AwesomeAlgo;

/// <summary>
/// Represents a number-name pair.
/// </summary>
public class NumberNamePair
{
    /// <summary>
    /// Gets the number of the pair.
    /// </summary>
    public int Number { get; }

    /// <summary>
    /// Gets the name of the pair.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="NumberNamePair"/> class.
    /// </summary>
    /// <param name="number">The number of the pair. Must be between 1 and <see cref="int.MaxValue"/>.</param>
    /// <param name="name">The name of the pair. Must not be null or whitespace and only contain alphabetical characters.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the number is not within the valid range.</exception>
    /// <exception cref="ArgumentException">Thrown when the name is null, whitespace, or contains non-alphabetical characters.</exception>
    public NumberNamePair(int number, string name)
    {
        // Ensuring the number is within the range 1 to Int32.MaxValue
        if (number < 1 || number > int.MaxValue) 
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be between 1 and Int32.MaxValue.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));

        if (!System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z ]+$"))
            throw new ArgumentException("Name must only contain alphabetical characters.");

        Number = number;
        Name = name;
    }
}
