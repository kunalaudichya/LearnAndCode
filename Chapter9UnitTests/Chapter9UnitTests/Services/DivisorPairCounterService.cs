using Chapter9UnitTests.Services.Interfaces;

namespace Chapter9UnitTests.Services
{
    public class DivisorPairCounterService
    {
        private readonly IDivisorCalculatorService _divisorCalculatorService;

        public DivisorPairCounterService(IDivisorCalculatorService divisorCalculatorService)
        {
            _divisorCalculatorService = divisorCalculatorService
                ?? throw new ArgumentNullException(nameof(divisorCalculatorService));
        }

        public int CountEqualDivisorPairs(int k)
        {
            int count = 0;

            for (int n = 2; n < k; n++)
            {
                int divisor1 = _divisorCalculatorService.CountTotalDivisors(n);
                int divisor2 = _divisorCalculatorService.CountTotalDivisors(n + 1);

                if (divisor1 == divisor2)
                    count++;
            }

            return count;
        }
    }
}
