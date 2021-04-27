using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MicroserviceLibrary.Application.Configurations.Dispatchers;
using MicroserviceLibrary.Application.Utils;
using MicroserviceLibrary.Domain.Repositories;
using PlainClasses.Services.Platoon.Application.Rules;
using PlainClasses.Services.Platoon.Domain.Models.DomainServices;

namespace PlainClasses.Services.Platoon.Application.Commands.DeletePlatoon
{
    public class DeletePlatoonCommandHandler : ICommandHandler<DeletePlatoonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetPlatoonForId _getPlatoonForId;

        public DeletePlatoonCommandHandler(IUnitOfWork unitOfWork, IGetPlatoonForId getPlatoonForId)
        {
            _unitOfWork = unitOfWork;
            _getPlatoonForId = getPlatoonForId;
        }
        
        public async Task<Unit> Handle(DeletePlatoonCommand request, CancellationToken cancellationToken)
        {
            var platoon = await _getPlatoonForId.GetAsync(request.PlatoonId);
            ExceptionHelper.CheckRule(new PlatoonDoesNotExistRule(platoon));

            await _unitOfWork.Repository<Domain.Models.Platoon>().DeleteAsync(platoon);
            await _unitOfWork.CommitAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}