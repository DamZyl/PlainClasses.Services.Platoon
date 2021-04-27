using System;
using MicroserviceLibrary.Application.Configurations.Dispatchers;

namespace PlainClasses.Services.Platoon.Application.Commands.UpdatePlatoon
{
    public class UpdatePlatoonCommand : CommandBase
    {
        public Guid PlatoonId { get; set; }
        public string Commander { get; }

        public UpdatePlatoonCommand(Guid platoonId, string commander)
        {
            PlatoonId = platoonId;
            Commander = commander;
        }
    }
}