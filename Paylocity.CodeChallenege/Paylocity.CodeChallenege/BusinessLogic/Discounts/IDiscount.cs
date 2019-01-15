using Paylocity.CodeChallenege.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.CodeChallenege.BusinessLogic.Discounts
{
    public interface IDiscount
    {
        CustomerCostModel Evaluate(CustomerCostModel customerCostModel);
    }
}
