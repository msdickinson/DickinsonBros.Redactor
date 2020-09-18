using DickinsonBros.Redactor.Configurator;
using DickinsonBros.Redactor.Models;
using DickinsonBros.Test;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace DickinsonBros.Redactor.Tests.Configurator
{

    [TestClass]
    public class RedactorServiceOptionsConfiguratorTests : BaseTest
    {
        public const string ADMIN_TOKEN = "ExampleToken";

        [TestMethod]
        public async Task Configure_Runs_DecryptCalled()
        {
            var accountAPITestsOptions = new RedactorServiceOptions
            {
                PropertiesToRedact = new string[] {"SampleProp"},
                RegexValuesToRedact = new string[] { "SampleRegexValues" }
            };
            var configurationRoot = BuildConfigurationRoot(accountAPITestsOptions);

            await RunDependencyInjectedTestAsync
            (
                async (serviceProvider) =>
                {
                    //Setup
                 
                    //Act
                    var options = serviceProvider.GetRequiredService<IOptions<RedactorServiceOptions>>().Value;

                    //Assert
                    Assert.IsNotNull(options);

                    Assert.AreEqual(accountAPITestsOptions.PropertiesToRedact.Count(), options.PropertiesToRedact.Count());
                    Assert.AreEqual(accountAPITestsOptions.PropertiesToRedact.First(), options.PropertiesToRedact.First());

                    Assert.AreEqual(accountAPITestsOptions.RegexValuesToRedact.Count(), options.RegexValuesToRedact.Count());
                    Assert.AreEqual(accountAPITestsOptions.RegexValuesToRedact.First(), options.RegexValuesToRedact.First());

                    await Task.CompletedTask.ConfigureAwait(false);

                },
                serviceCollection => ConfigureServices(serviceCollection, configurationRoot)
            );
        }

        #region Helpers

        private IServiceCollection ConfigureServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions();
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<IConfigureOptions<RedactorServiceOptions>, RedactorServiceOptionsConfigurator>();

            return serviceCollection;
        }

        #endregion
    }
}
