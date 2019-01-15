using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paylocity.CodeChallenege.BusinessLogic.Discounts;
using Paylocity.CodeChallenege.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.CodeChallenege.BusinessLogic
{
    public static class DiscountServicExtension
    {
        public static IServiceCollection RegisterDiscountEngine(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                services.Configure<FirstNameDiscountOptions>(configuration.GetSection("FirstNameDiscountOptions"));

                services.AddSingleton<IDiscountEngine, DiscountEngine>();

                var discounts = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
                                .Where(x => typeof(IDiscount).IsAssignableFrom(x)
                                    && x.GetInterfaces().Contains(typeof(IDiscount))
                                    && !x.IsInterface && !x.IsAbstract);

                foreach (var discount in discounts)
                {
                    services.AddSingleton(typeof(IDiscount), discount);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Unable to Register Discount Engine", ex);
            }

            return services;
        }
    }
}
