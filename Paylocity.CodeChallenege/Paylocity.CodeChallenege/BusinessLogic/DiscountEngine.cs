using Microsoft.Extensions.Options;
using Paylocity.CodeChallenege.BusinessLogic.Discounts;
using Paylocity.CodeChallenege.Configuration;
using Paylocity.CodeChallenege.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.CodeChallenege.BusinessLogic
{    
    public class DiscountEngine : IDiscountEngine
    {
        private readonly IEnumerable<IDiscount> _discounts;
        private readonly CostOptions _costOptions;

        public DiscountEngine(IEnumerable<IDiscount> discounts, IOptions<CostOptions> costOptions)
        {
            _costOptions = costOptions.Value ?? throw new ArgumentNullException(nameof(costOptions.Value));
            _discounts = discounts ?? throw new ArgumentNullException(nameof(discounts));
        }

        public async Task<CustomerCostResponse> Apply(string name, string customerType)
        {
            var coverageCost = string.Equals(customerType, "c", StringComparison.CurrentCultureIgnoreCase) 
                               ? _costOptions.CustomerBaseCost 
                               : _costOptions.DependentBaseCost;

            var result = new CustomerCostResponse
            {
                CustomerCostModel = new CustomerCostModel
                {
                    CoverageCost = coverageCost,
                    Name = name
                }
            };

            foreach (var discount in _discounts)
            {
                result.CustomerCostModel = discount.Evaluate(result.CustomerCostModel);
            }       

            return result;
        }
    }
}
