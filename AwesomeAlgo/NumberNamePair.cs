namespace AwesomeAlgo;

public class NumberNamePair
{
    public int Number { get; }
    public string Name { get; }

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
