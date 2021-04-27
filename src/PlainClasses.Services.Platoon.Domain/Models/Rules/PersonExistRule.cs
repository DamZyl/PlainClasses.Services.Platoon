using MicroserviceLibrary.Domain.SharedKernels;

namespace PlainClasses.Services.Platoon.Domain.Models.Rules
{
    public class PersonExistRule : IBusinessRule
    {
        // private readonly Person _person;
        //
        // public PersonExistRule(Person person)
        // {
        //     _person = person;
        // }

        public bool IsBroken() => true; // => _person == null;

        public string Message => ""; // $"Person with id: {_person.Id} does not exist.";
    }
}