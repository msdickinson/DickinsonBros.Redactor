﻿using DickinsonBros.Redactor.Abstractions;
using DickinsonBros.Redactor.Configurator;
using DickinsonBros.Redactor.Extensions;
using DickinsonBros.Redactor.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DickinsonBros.Redactor.Tests.Extensions
{
    [TestClass]
    public class IServiceCollectionExtensionsTests
    {
        [TestMethod]
        public void AddDateTimeService_Should_Succeed()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            serviceCollection.AddRedactorService();

            // Assert
            Assert.IsTrue(serviceCollection.Any(serviceDefinition => serviceDefinition.ServiceType == typeof(IRedactorService) &&
                                                       serviceDefinition.ImplementationType == typeof(RedactorService) &&
                                                       serviceDefinition.Lifetime == ServiceLifetime.Singleton));

            Assert.IsTrue(serviceCollection.Any(serviceDefinition => serviceDefinition.ServiceType == typeof(IConfigureOptions<RedactorServiceOptions>) &&
                                           serviceDefinition.ImplementationType == typeof(RedactorServiceOptionsConfigurator) &&
                                           serviceDefinition.Lifetime == ServiceLifetime.Singleton));
        }
    }
}
