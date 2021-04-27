using System;
using MicroserviceLibrary.Domain.SharedKernels;

namespace PlainClasses.Services.Platoon.Domain.Models.Events
{
    public class PersonToPlatoonAddedEvent : DomainEventBase
    {
        public Guid PlatoonId { get; private set; }
        public Guid PersonId { get; private set; }

        public PersonToPlatoonAddedEvent(Guid platoonId, Guid personId)
        {
            PlatoonId = platoonId;
            PersonId = personId;
        }
    }
}