using System;
using System.Collections.Generic;
using System.Linq;
using DependencyIOC.DependencyInjection;

namespace DependencyIOC
{
    public class DiContainer
    {
        private readonly List<ServiceDescriptor> _serviceDescriptors;

        public DiContainer(List<ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }

        public object GetService(Type serviceType)
        {
            var descriptor = _serviceDescriptors
                .SingleOrDefault(x => x.ServiceType == serviceType);

            ThrowExceptionIfObjectNull(descriptor, serviceType);
            //ReturnImplementationIfNotNUL(descriptor);
            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            ThrowExceptionIfTypeIsAbstractOrInterface(actualType);

            var constructorInfo = actualType.GetConstructors().First();

            var parameters = constructorInfo.GetParameters()
                .Select(x => GetService(x.ParameterType)).ToArray();

            var implementation = Activator.CreateInstance(actualType, parameters);

            if (descriptor.Lifetime == ServiceLifetime.Singleton)
            {
                descriptor.Implementation = implementation;
            }

            return implementation;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        public void ThrowExceptionIfObjectNull(ServiceDescriptor descriptor, Type serviceType)
        {
            if (descriptor == null)
            {
                throw new Exception($"Service of type {serviceType.Name} isn't registered");
            }
        }

       // public object ReturnImplementationIfNotNUL(ServiceDescriptor descriptor)
        //{
         //   if (descriptor.Implementation != null)
         //   {
              //  return descriptor.Implementation;
          //  }
          //  else return null;
            
        //}
        public void ThrowExceptionIfTypeIsAbstractOrInterface(Type actualType)
        {
            if (actualType.IsAbstract)
            {
                throw new Exception("Cannot instantiate abstract classes or interfaces");
            }
        }

    }
}