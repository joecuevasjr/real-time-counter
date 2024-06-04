namespace AwesomeAlgo
{
    public class NumberNamePairManager
    {
        private readonly Dictionary<int, string> _pairs = new Dictionary<int, string>();

        public void AddOrReplacePair(int number, string name)
        {
            if (_pairs.ContainsKey(number))
            {
                // "Log" the replacement
                Console.WriteLine($"Replacing existing entry for number {number}.");
            }

            // Add or update pair
            _pairs[number] = name;
        }

        public string GetNameForNumber(int number)
        {
            List<string> names = new List<string>();
            foreach (var pair in _pairs)
            {
                // Skip any pair with a zero number to avoid division by zero
                if (pair.Key == 0)
                    continue;  

                if (number % pair.Key == 0)
                {
                    names.Add(pair.Value);
                }
            }
            return names.Count > 0 ? string.Join(" ", names) : number.ToString();
        }
    }
}
