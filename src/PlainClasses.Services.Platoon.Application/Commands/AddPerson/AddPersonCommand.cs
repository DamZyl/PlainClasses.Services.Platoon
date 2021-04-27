using System;
using MicroserviceLibrary.Application.Configurations.Dispatchers;
using PlainClasses.Services.Platoon.Application.Commands.CreatePlatoon;

namespace PlainClasses.Services.Platoon.Application.Commands.AddPerson
{
    public class AddPersonCommand : CommandBase<ReturnPlatoonViewModel>
    {
        public Guid PlatoonId { get; set; }
        public Guid PersonId { get; set; }

        public AddPersonCommand(Guid platoonId, Guid personId)
        {
            PlatoonId = platoonId;
            PersonId = personId;
        }
    }
}