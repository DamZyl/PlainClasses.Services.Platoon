using MicroserviceLibrary.Application.Configurations.Dispatchers;

namespace PlainClasses.Services.Platoon.Application.Commands.CreatePlatoon
{
    public class CreatePlatoonCommand : CommandBase<ReturnPlatoonViewModel>
    {
        public string Name { get; }
        public string Acronym { get; }
        public string Commander { get; }

        public CreatePlatoonCommand(string name, string acronym, string commander)
        {
            Name = name;
            Acronym = acronym;
            Commander = commander;
        }
    }
}