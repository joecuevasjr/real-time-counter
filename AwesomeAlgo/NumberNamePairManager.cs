namespace AwesomeAlgo;

public class NumberNamePairManager
{
    private readonly Dictionary<int, string> _pairs = new Dictionary<int, string>();

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
