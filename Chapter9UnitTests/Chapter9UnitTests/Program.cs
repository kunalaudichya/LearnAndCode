using Chapter9UnitTests.Services;
using Chapter9UnitTests.Services.Interfaces;

namespace Chapter9UnitTests
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                if (!int.TryParse(Console.ReadLine(), out int testCases) || testCases <= 0)
                {
                    Console.WriteLine("Invalid number of test cases.");
                    return;
                }

                int[] inputs = new int[testCases];

                for (int i = 0; i < testCases; i++)
                {
                    if (!int.TryParse(Console.ReadLine(), out inputs[i]))
                    {
                        Console.WriteLine("Invalid input detected.");
                        return;
                    }
                }

                IDivisorCalculatorService calculator = new DivisorCalculatorService();
                DivisorPairCounterService counter = new DivisorPairCounterService(calculator);
                Console.WriteLine("\nResult: ");

                foreach (int k in inputs)
                {
                    Console.WriteLine(counter.CountEqualDivisorPairs(k));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }
    }
}
