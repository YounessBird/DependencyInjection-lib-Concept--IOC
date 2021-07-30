using System;

namespace DependencyIOC
{
    internal class RandomGuidGenerator : IRandomGuidGenerator
    {
        public Guid RandomGuid { get; } = Guid.NewGuid();
    }
}