using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MicroserviceLibrary.Application.Configurations.Dispatchers;
using MicroserviceLibrary.Application.Utils;
using MicroserviceLibrary.Domain.Repositories;
using PlainClasses.Services.Platoon.Application.Rules;
using PlainClasses.Services.Platoon.Domain.Models.DomainServices;

namespace PlainClasses.Services.Platoon.Application.Commands.UpdatePlatoon
{
    public class UpdatePlatoonCommandHandler : ICommandHandler<UpdatePlatoonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetPlatoonForId _getPlatoonForId;

        public UpdatePlatoonCommandHandler(IUnitOfWork unitOfWork, IGetPlatoonForId getPlatoonForId)
        {
            _unitOfWork = unitOfWork;
            _getPlatoonForId = getPlatoonForId;
        }
        
        public async Task<Unit> Handle(UpdatePlatoonCommand request, CancellationToken cancellationToken)
        {
            var platoon = await _getPlatoonForId.GetDetailAsync(request.PlatoonId);
            ExceptionHelper.CheckRule(new PlatoonDoesNotExistRule(platoon));

            platoon.UpdatePlatoonData(request.Commander);

            await _unitOfWork.Repository<Domain.Models.Platoon>().EditAsync(platoon);
            await _unitOfWork.CommitAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}