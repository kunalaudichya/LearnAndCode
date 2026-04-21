using Chapter9UnitTests.Services;
using Chapter9UnitTests.Services.Interfaces;

namespace Chapter9UnitTests.Tests
{
    public class DivisorPairCounterServiceTests
    {

        private readonly DivisorPairCounterService _divisorPairCounterService =
           new DivisorPairCounterService(new DivisorCalculatorService());

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(3, 1)]
        [InlineData(4, 1)]
        [InlineData(10, 1)]
        [InlineData(16, 2)]
        public void CountEqualDivisorPairs_ReturnExpected(int k, int expected)
        {
            int result = _divisorPairCounterService.CountEqualDivisorPairs(k);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountEqualDivisorPairs_SmallInput_ReturnsZero()
        {
            int result = _divisorPairCounterService.CountEqualDivisorPairs(1);

            Assert.Equal(0, result);
        }
    }
}


