using System;
namespace Week2.Assignment2
{
    public class SubArrayMeanCalculator
    {
        public void Main()
        {
            var (numbers, queries) = InputReader.ReadInput();

            var subarrayService = new SubarrayService(numbers);

            foreach (Query query in queries)
            {
                long mean = subarrayService.GetSubarrayMean(query);
                Console.WriteLine(mean);
            }
        }
    }
}
