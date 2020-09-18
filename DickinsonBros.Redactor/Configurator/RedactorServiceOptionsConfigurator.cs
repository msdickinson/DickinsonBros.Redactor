using DickinsonBros.Redactor.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
namespace DickinsonBros.Redactor.Configurator
{
    public class RedactorServiceOptionsConfigurator : IConfigureOptions<RedactorServiceOptions>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public RedactorServiceOptionsConfigurator(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        void IConfigureOptions<RedactorServiceOptions>.Configure(RedactorServiceOptions options)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var provider = scope.ServiceProvider;
            var configuration = provider.GetRequiredService<IConfiguration>();
            var accountAPITestsOptions = configuration.GetSection(nameof(RedactorServiceOptions)).Get<RedactorServiceOptions>();
            configuration.Bind($"{nameof(RedactorServiceOptions)}", options);
        }
    }
}
