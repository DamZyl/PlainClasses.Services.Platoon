using MicroserviceLibrary.Domain.SharedKernels;

namespace PlainClasses.Services.Platoon.Application.Rules
{
    public class PlatoonDoesNotExistRule : IBusinessRule
    {
        private readonly Domain.Models.Platoon _platoon;

        public PlatoonDoesNotExistRule(Domain.Models.Platoon platoon)
        {
            _platoon = platoon;
        }

        public bool IsBroken() => _platoon == null;

        public string Message => $"Platoon with id: {_platoon.Id} does not exist.";
    }
}