using Chapter9UnitTests.Services.Interfaces;

namespace Chapter9UnitTests.Services
{
    public class DivisorCalculatorService : IDivisorCalculatorService
    {
        public int CountTotalDivisors(int number)
        {
            int count = 0;

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                    count++;
            }

            return count;
        }
    }
}
