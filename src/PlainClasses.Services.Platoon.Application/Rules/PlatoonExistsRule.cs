using MicroserviceLibrary.Domain.SharedKernels;
using PlainClasses.Services.Platoon.Application.Queries.GetPlatoon;

namespace PlainClasses.Services.Platoon.Application.Rules
{
    public class PlatoonExistsRule : IBusinessRule
    {
        private readonly PlatoonDetailViewModel _platoon;

        public PlatoonExistsRule(PlatoonDetailViewModel platoon)
        {
            _platoon = platoon;
        }

        public bool IsBroken() => _platoon == null;

        public string Message => $"Platoon with id: {_platoon.Id} does not exist.";
    }
}