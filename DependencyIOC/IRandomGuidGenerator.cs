using System;

namespace DependencyIOC
{
    public interface IRandomGuidGenerator
    {
        Guid RandomGuid { get; }

    }
}