using System;
using System.Collections.Generic;
using Xunit;

namespace DependencyIOC.Tests
{
    public class DiContainerTests
    {
        [Fact]
        public void ShouldThrowExceptionIfObjectNull()
        {
            //Arrange
            ServiceDescriptor descriptor = null;
            List<ServiceDescriptor> serviceDescriptors = new List<ServiceDescriptor> { descriptor };
            DiContainer diContainer = new DiContainer(serviceDescriptors);
            //Act

            //Assert
            Assert.Throws<Exception>(() => diContainer.ThrowExceptionIfObjectNull(descriptor, typeof(SomeService)));
        }

        [Fact]
        public void ShouldThrowExceptionIfTypeIsAbstractOrInterface()
        {
            //Arrange
            ServiceDescriptor descriptor = null;
            List<ServiceDescriptor> serviceDescriptors = new List<ServiceDescriptor> { descriptor };
            DiContainer diContainer = new DiContainer(serviceDescriptors);
            //Assert
            Assert.Throws<Exception>(() => diContainer.ThrowExceptionIfTypeIsAbstractOrInterface(typeof(AbstractTypeTest)));
        }


        [Fact]
        public void ShouldGetService()
        {
            //Arrange
            SomeSerivceTest service = new SomeSerivceTest();
            ServiceDescriptor descriptor = new ServiceDescriptor(service,ServiceLifetime.Singleton);
            List<ServiceDescriptor> serviceDescriptors = new List<ServiceDescriptor> { descriptor };
            DiContainer diContainer = new DiContainer(serviceDescriptors);
            //Assert
            Assert.True(service.Equals(diContainer.GetService<SomeSerivceTest>()));
        }

    }
}
