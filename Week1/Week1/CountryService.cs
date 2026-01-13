using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    internal class CountryService
    {
        private readonly Dictionary<string, List<string>> _countryService;
        public CountryService()
        {
            _countryService = new Dictionary<string, List<string>>()
            {
                { "IN", new List<string>
                    { "Pakistan", "China", "Nepal", "Bhutan", "Bangladesh", "Myanmar", "Sri Lanka", "Afghanistan" }
                },
                { "US", new List<string>
                    { "Canada", "Mexico" }
                },
                { "NZ", new List<string>
                    { "Australia" }
                },
                { "CA", new List<string>
                    { "United States of America" }
                },
                { "MX", new List<string>
                    { "United States of America", "Guatemala", "Belize" }
                },
                { "CN", new List<string>
                    { "India", "Pakistan", "Nepal", "Bhutan", "Afghanistan", "Russia", "Mongolia", "North Korea", "Laos", "Vietnam", "Myanmar", "Kazakhstan", "Kyrgyzstan", "Tajikistan" }
                },
                { "AU", new List<string>
                    { "New Zealand" }
                },
                { "PK", new List<string>
                    { "India", "Afghanistan", "Iran", "China" }
                },
                { "JP", new List<string>() },
                { "DE", new List<string> 
                    { "France", "Belgium", "Netherlands", "Poland", "Czechia", "Austria", "Switzerland", "Luxembourg" } 
                },
                { "FR", new List<string> 
                    { "Belgium", "Luxembourg", "Germany", "Switzerland", "Italy", "Spain" } 
                },
            };
        }

        public string GetAdjacentCountryName(string countryCode)
        {
            if (string.IsNullOrWhiteSpace(countryCode))
                return "Invalid input";

            countryCode = countryCode.ToUpper();

            if (_countryService.ContainsKey(countryCode))
            {
                var adjacentCountries = _countryService[countryCode];

                if (!adjacentCountries.Any())
                    return "No adjacent countries";

                return string.Join(", ", adjacentCountries);
            }

            return "No Country found";
        }
    }
}
