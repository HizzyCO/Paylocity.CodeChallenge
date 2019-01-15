using System.Collections.Generic;

namespace Paylocity.CodeChallenege.Models
{
    public class CustomerCostResponse
    {
        public CustomerCostModel CustomerCostModel { get; set; }
        public bool Success { get; set; }
        public IList<string> Errors { get; set; } //ToDo Create Error Object To Store Meta Data
    }
}