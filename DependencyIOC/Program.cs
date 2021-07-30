using System;
using System.Collections.Generic;
using System.Reflection;


namespace DependencyIOC
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var services = new DiServiceCollection();

            // Register service as a singleton 
            services.RegisterSingleton<IRandomGuidGenerator, RandomGuidGenerator>();
            //services.RegisterTransient<IRandomGuidGenerator, RandomGuidGenerator>();
            //services.RegisterSingleton<ILevel2, Level2>();
            //services.RegisterSingleton<ILevel3, Level3>();
            services.RegisterSingleton<ISomeService, SomeService>();
            //services.RegisterTransient<ISomeService, SomeService>();

            var container = services.GenerateContainer();

            var serviceFirst = container.GetService<ISomeService>();
            var serviceSecond = container.GetService<ISomeService>();


            serviceFirst.PrintGuid();
            serviceSecond.PrintGuid();

        }
    }
}
