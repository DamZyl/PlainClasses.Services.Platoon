using System;
using MicroserviceLibrary.Application.Configurations.Dispatchers;

namespace PlainClasses.Services.Platoon.Application.Commands.DeletePerson
{
    public class DeletePersonFromPlatoonCommand : CommandBase
    {
        public Guid PlatoonId { get; }
        public Guid PersonId { get; }

        public DeletePersonFromPlatoonCommand(Guid platoonId, Guid personId)
        {
            PlatoonId = platoonId;
            PersonId = personId;
        }
    }
}