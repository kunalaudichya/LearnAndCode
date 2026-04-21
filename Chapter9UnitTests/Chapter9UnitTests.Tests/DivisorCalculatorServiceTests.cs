using Chapter9UnitTests.Services;

namespace Chapter9UnitTests.Tests
{
    public class DivisorCalculatorServiceTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(6, 4)]
        [InlineData(7, 2)]
        [InlineData(10, 4)]
        [InlineData(12, 6)]
        public void CountTotalDivisors_KnownValues(int number, int expectedDivisors)
        {
            var service = new DivisorCalculatorService();

            int result = service.CountTotalDivisors(number);

            Assert.Equal(expectedDivisors, result);
        }
    }
}
