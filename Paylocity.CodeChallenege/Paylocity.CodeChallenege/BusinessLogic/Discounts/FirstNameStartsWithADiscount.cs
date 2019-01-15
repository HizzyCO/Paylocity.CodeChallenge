using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Paylocity.CodeChallenege.Configuration;
using Paylocity.CodeChallenege.Models;

namespace Paylocity.CodeChallenege.BusinessLogic.Discounts
{
    public class FirstNameStartsWithADiscount : IDiscount
    {
        private readonly FirstNameDiscountOptions _discountOptions;

        public FirstNameStartsWithADiscount(IOptions<FirstNameDiscountOptions> discountOptions)
        {
            _discountOptions = discountOptions.Value ?? throw new ArgumentNullException(nameof(discountOptions.Value));
        }
        public CustomerCostModel Evaluate(CustomerCostModel customerCostModel)
        {    
            if (customerCostModel.CoverageCost > 0)
            {
                if (string.Equals(customerCostModel.Name[0].ToString(), _discountOptions.FirstLetterValue, StringComparison.CurrentCultureIgnoreCase))
                {                    
                    customerCostModel.CoverageCost -= (customerCostModel.CoverageCost * _discountOptions.DiscountPercetage);
                }
            }
            
            return customerCostModel;
        }
    }
}
