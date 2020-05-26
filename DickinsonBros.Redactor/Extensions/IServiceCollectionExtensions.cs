using DickinsonBros.Redactor.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DickinsonBros.Redactor.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRedactorService(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton<IRedactorService, RedactorService>();
            return serviceCollection;
        }
    }
}
