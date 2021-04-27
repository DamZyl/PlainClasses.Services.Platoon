using System.Threading;
using System.Threading.Tasks;
using MicroserviceLibrary.Application.Configurations.Dispatchers;
using MicroserviceLibrary.Application.Utils;
using MicroserviceLibrary.Domain.Repositories;
using PlainClasses.Services.Platoon.Application.Commands.CreatePlatoon;
using PlainClasses.Services.Platoon.Application.Rules;
using PlainClasses.Services.Platoon.Domain.Models.DomainServices;

namespace PlainClasses.Services.Platoon.Application.Commands.AddPerson
{
    public class AddPersonCommandHandler : ICommandHandler<AddPersonCommand, ReturnPlatoonViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IGetPersonForId _getPersonForId;
        private readonly IChangePlatoonForPerson _changePlatoonForPerson;

        public AddPersonCommandHandler(IUnitOfWork unitOfWork,// IGetPersonForId getPersonForId, 
            IChangePlatoonForPerson changePlatoonForPerson)
        {
            _unitOfWork = unitOfWork;
           // _getPersonForId = getPersonForId;
            _changePlatoonForPerson = changePlatoonForPerson;
        }
        
        public async Task<ReturnPlatoonViewModel> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var platoon = await _unitOfWork.Repository<Domain.Models.Platoon>()
                .FindByIdAsync(request.PlatoonId);
            
            ExceptionHelper.CheckRule(new PlatoonDoesNotExistRule(platoon));
            
            // platoon.AddPersonToPlatoon(request.PersonId, _getPersonForId, _changePlatoonForPerson);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ReturnPlatoonViewModel { Id = platoon.Id };
        }
    }
}