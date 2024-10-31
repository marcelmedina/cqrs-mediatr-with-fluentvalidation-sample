using CQRSAndMediatrWithFluentValidationSampleApplication.Product.Pipeline;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CQRSAndMediatrWithFluentValidationSampleApplication.Product
{
    public static class ProductModule
    {
        public static IServiceCollection AddProductModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return serviceCollection;
        }
    }
}
