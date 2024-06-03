namespace AwesomeAlgo
{
    public class AwesomeAlgoClass
    {
        public async IAsyncEnumerable<string> CountToUpperBoundAsync(int upperBound)
        {

            for (int i = 0; i < upperBound; i++)
            {
                var value = i + 1;

                if (value % 3 == 0 && value % 5 != 0)
                {
                    yield return "Joe";
                }
                else if (value % 5 == 0 && value % 3 != 0)
                {
                    yield return "Cuevas";
                }
                else if (value % 5 == 0 && value % 3 == 0)
                {
                    yield return "Joe Cuevas";
                }
                else
                {
                    yield return value.ToString();
                }

                await Task.Delay(50); // Simulate delay
            }
        }
    }
}
