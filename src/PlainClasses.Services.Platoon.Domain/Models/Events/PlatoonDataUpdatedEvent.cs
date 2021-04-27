using System;
using MicroserviceLibrary.Domain.SharedKernels;

namespace PlainClasses.Services.Platoon.Domain.Models.Events
{
    public class PlatoonDataUpdatedEvent : DomainEventBase
    {
        public Guid PlatoonId { get; private set; }

        public PlatoonDataUpdatedEvent(Guid platoonId)
        {
            PlatoonId = platoonId;
        }
    }
}