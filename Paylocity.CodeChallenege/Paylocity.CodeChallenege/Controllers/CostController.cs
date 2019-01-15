using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Paylocity.CodeChallenege.BusinessLogic;
using Paylocity.CodeChallenege.Configuration;
using Paylocity.CodeChallenege.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.CodeChallenege.Controllers
{
    //ToDo: Create Disocunt Micro Service
    [Route("api/cost")]
    public class CostController : Controller
    {
        private readonly IDiscountEngine _discountEngine;

        public CostController(IDiscountEngine discountEngine)
        {
            _discountEngine = discountEngine ?? throw new ArgumentNullException(nameof(discountEngine));
        }

        [HttpGet]
        [Route("{name}/{customertype}")]
        public async Task<IActionResult> GetCostByName(string name, string customerType)
        {
            if (customerType != "c" || customerType != "d")
            {
                return StatusCode(400); //Could be a 422 as well
            }

            var result = await _discountEngine.Apply(name, customerType);

            if (!result.Success)
            {
                return StatusCode(500); // Todo: Add more response codes depending on actual fault
            }

            return await Task.FromResult(Ok());
        }
    }
}
