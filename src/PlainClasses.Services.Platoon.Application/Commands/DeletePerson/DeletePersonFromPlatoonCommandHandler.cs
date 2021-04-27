using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MicroserviceLibrary.Application.Configurations.Dispatchers;
using MicroserviceLibrary.Application.Utils;
using MicroserviceLibrary.Domain.Repositories;
using PlainClasses.Services.Platoon.Application.Rules;
using PlainClasses.Services.Platoon.Domain.Models.DomainServices;

namespace PlainClasses.Services.Platoon.Application.Commands.DeletePerson
{
    public class DeletePersonFromPlatoonCommandHandler : ICommandHandler<DeletePersonFromPlatoonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IGetPersonForId _getPersonForId;
        private readonly IChangePlatoonForPerson _changePlatoonForPerson;

        public DeletePersonFromPlatoonCommandHandler(IUnitOfWork unitOfWork, //IGetPersonForId getPersonForId, 
            IChangePlatoonForPerson changePlatoonForPerson)
        {
            _unitOfWork = unitOfWork;
            //_getPersonForId = getPersonForId;
            _changePlatoonForPerson = changePlatoonForPerson;
        }
        
        public async Task<Unit> Handle(DeletePersonFromPlatoonCommand request, CancellationToken cancellationToken)
        {
            var platoon = await _unitOfWork.Repository<Domain.Models.Platoon>()
                .FindByIdAsync(request.PlatoonId);
            ExceptionHelper.CheckRule(new PlatoonDoesNotExistRule(platoon));
            
            // platoon.DeletePersonFromPlatoon(request.PersonId, _getPersonForId, _changePlatoonForPerson);

            await _unitOfWork.CommitAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}