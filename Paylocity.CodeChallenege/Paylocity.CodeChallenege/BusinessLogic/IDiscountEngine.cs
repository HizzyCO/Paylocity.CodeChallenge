using Paylocity.CodeChallenege.Models;
using System.Threading.Tasks;

namespace Paylocity.CodeChallenege.BusinessLogic
{
    public interface IDiscountEngine
    {
        Task<CustomerCostResponse> Apply(string name, string customerType);
    }
}