using System;
using MicroserviceLibrary.Domain.SharedKernels;
using PlainClasses.Services.Platoon.Domain.Models.Events;

namespace PlainClasses.Services.Platoon.Domain.Models
{
    public class Platoon : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Acronym { get; private set; }
        public string Commander { get; private set; }

        private Platoon() { }

        private Platoon(string name, string acronym, string commander)
        {
            Id = Guid.NewGuid();
            Name = name;
            Acronym = acronym;
            Commander = commander;
            
            AddDomainEvent(new PlatoonCreatedEvent(Id));
        }

        public static Platoon CreatePlatoon(string name, string acronym, string commander)
            => new Platoon(name, acronym, commander);

        public void UpdatePlatoonData(string commander)
        {
            if (Commander != commander)
            {
                Commander = commander;
            }
            
            AddDomainEvent(new PlatoonDataUpdatedEvent(Id));
        }

        // public void AddPersonToPlatoon(Guid personId, IGetPersonForId getPersonForId, 
        //     IChangePlatoonForPerson changePlatoonForPerson)
        // {
        //     var person = getPersonForId.GetDetail(personId);
        //     CheckRule(new PersonExistRule(person));
        //     CheckRule(new PersonIsInPlatoonRule(_persons, person));
        //     
        //     changePlatoonForPerson.ChangePlatoon(person, Id);
        //     _persons.Add(person);
        //     
        //     AddDomainEvent(new PersonToPlatoonAddedEvent(Id, person.Id));
        // }
        //
        // public void DeletePersonFromPlatoon(Guid personId, IGetPersonForId getPersonForId, 
        //     IChangePlatoonForPerson changePlatoonForPerson)
        // {
        //     var person = getPersonForId.GetDetail(personId);
        //     CheckRule(new PersonExistRule(person));
        //     CheckRule(new PersonExistsInPlatoonRule(_persons, person.Id));
        //     
        //     changePlatoonForPerson.ChangePlatoon(person);
        //     _persons.Remove(_persons.Single(x => x.Id == person.Id));
        //     
        //     AddDomainEvent(new PersonFromPlatoonDeletedEvent(Id, person.Id));
        // }
    }
}