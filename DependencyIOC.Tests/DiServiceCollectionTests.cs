using System;
using System.Collections.Generic;
using Xunit;

namespace DependencyIOC.Tests
{
    public class DiServiceCollectionTests
    {
        [Fact]
        public void ShouldRegisterSingleton()
        {
            //Arrange
            DiServiceCollection services = new DiServiceCollection();
            //Act
            services.RegisterSingleton<SomeSerivceTest>();
            var container = services.GenerateContainer();
            var actualService = container.GetService<SomeSerivceTest>();
            //Assert
            Assert.NotNull(actualService);
            Assert.IsType<SomeSerivceTest>(actualService);


            //Act
            services.RegisterSingleton<ISomeSerivceTest, SomeSerivceTest>();
            var actualServiceOne = container.GetService<ISomeSerivceTest>();
            //Assert
            Assert.NotNull(actualServiceOne);
            Assert.IsType<SomeSerivceTest>(actualServiceOne);

        }

        [Fact]
        public void RegisterTransient()
        {
            //Arrange
            DiServiceCollection services = new DiServiceCollection();
            //Act
            services.RegisterTransient<SomeSerivceTest>();
            var container = services.GenerateContainer();
            var actualService = container.GetService<SomeSerivceTest>();
            //Assert
            Assert.NotNull(actualService);
            Assert.IsType<SomeSerivceTest>(actualService);

        }
    }
}
