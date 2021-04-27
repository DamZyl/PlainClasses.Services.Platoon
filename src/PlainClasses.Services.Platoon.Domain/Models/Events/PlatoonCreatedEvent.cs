using System;
using MicroserviceLibrary.Domain.SharedKernels;

namespace PlainClasses.Services.Platoon.Domain.Models.Events
{
    public class PlatoonCreatedEvent : DomainEventBase
    {
        public Guid PlatoonId { get; private set; }

        public PlatoonCreatedEvent(Guid platoonId)
        {
            PlatoonId = platoonId;
        }
    }
}