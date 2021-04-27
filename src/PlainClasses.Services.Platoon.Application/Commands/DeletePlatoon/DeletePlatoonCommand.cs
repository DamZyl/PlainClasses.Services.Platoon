using System;
using MicroserviceLibrary.Application.Configurations.Dispatchers;

namespace PlainClasses.Services.Platoon.Application.Commands.DeletePlatoon
{
    public class DeletePlatoonCommand : CommandBase
    {
        public Guid PlatoonId { get; set; }

        public DeletePlatoonCommand(Guid platoonId)
        {
            PlatoonId = platoonId;
        }
    }
}