
namespace Week2.Assignment2
{
    public class SubarrayService
    {
        private readonly long[] _numbers;
        private readonly long[] _prefixSums;

        public SubarrayService(long[] numbers)
        {
            _numbers = numbers;
            _prefixSums = ComputePrefixSums(numbers);
        }

        private long[] ComputePrefixSums(long[] numbers)
        {
            long[] prefixSums = new long[numbers.Length + 1];
            for (int i = 1; i <= numbers.Length; i++)
            {
                prefixSums[i] = prefixSums[i - 1] + numbers[i - 1];
            }
            return prefixSums;
        }

        public long GetSubarrayMean(Query query)
        {
            long sum = _prefixSums[query.EndIndex] - _prefixSums[query.StartIndex - 1];
            long length = query.EndIndex - query.StartIndex + 1;
            return sum / length; 
        }
    }
}
