namespace AwesomeAlgo;

/// <summary>
/// Manages a collection of number-name pairs.
/// </summary>
public class NumberNamePairManager
{
    private readonly Dictionary<int, string> _pairs = new Dictionary<int, string>();

    /// <summary>
    /// Adds or replaces a number-name pair in the collection.
    /// </summary>
    /// <param name="number">The number of the pair. Must be positive and greater than zero.</param>
    /// <param name="name">The name of the pair. Must not be null or whitespace.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the number is not positive and greater than zero.</exception>
    /// <exception cref="ArgumentException">Thrown when the name is null or whitespace.</exception>
    public void AddOrReplacePair(int number, string name)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be positive and greater than zero.");
        
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));

        bool isReplacing = _pairs.ContainsKey(number);
        _pairs[number] = name;

        if (isReplacing)
        {
            Console.WriteLine($"Replacing existing Number/Name entry for number {number}.");
        }
        else
        {
            Console.WriteLine($"Added new Number/Name entry for number {number}.");
        }
    }

    /// <summary>
    /// Gets the concatenated names for a given number based on the divisibility rules.
    /// </summary>
    /// <param name="number">The number to check divisibility against the pairs.</param>
    /// <returns>A string representing the concatenated names or the number itself if no pairs are matched.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the number is not positive and greater than zero.</exception>
    public string GetNameForNumber(int number)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be positive and greater than zero.");

        List<string> names = new List<string>();
        foreach (var pair in _pairs)
        {
            if (number % pair.Key == 0)
            {
                names.Add(pair.Value);
            }
        }
        return names.Count > 0 ? string.Join(" ", names) : number.ToString();
    }
}
