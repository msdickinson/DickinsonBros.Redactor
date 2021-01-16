using DickinsonBros.Redactor.Abstractions;
using DickinsonBros.Redactor.Configurator;
using DickinsonBros.Redactor.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace DickinsonBros.Redactor.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRedactorService(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton<IRedactorService, RedactorService>();
            serviceCollection.AddSingleton<IConfigureOptions<RedactorServiceOptions>, RedactorServiceOptionsConfigurator>();
            return serviceCollection;
        }
    }
}
