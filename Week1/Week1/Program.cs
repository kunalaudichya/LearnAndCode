using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var countryService = new CountryService();

            Console.WriteLine("GUESS THE COUNTRY");

            while (true)
            {
                Console.WriteLine("Enter any Country Code or type 0 to exit: ");
                string code = Console.ReadLine()?.Trim() ?? "";

                if (code.Equals("0", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                string result = countryService.GetCountryName(code);
                Console.WriteLine($"Result: {result}\n");
            }
        }
    }
}
