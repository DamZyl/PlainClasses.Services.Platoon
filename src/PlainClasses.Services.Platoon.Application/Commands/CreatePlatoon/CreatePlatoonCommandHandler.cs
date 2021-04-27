using System.Threading;
using System.Threading.Tasks;
using MicroserviceLibrary.Application.Configurations.Dispatchers;
using MicroserviceLibrary.Domain.Repositories;

namespace PlainClasses.Services.Platoon.Application.Commands.CreatePlatoon
{
    public class CreatePlatoonCommandHandler : ICommandHandler<CreatePlatoonCommand, ReturnPlatoonViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePlatoonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<ReturnPlatoonViewModel> Handle(CreatePlatoonCommand request, CancellationToken cancellationToken)
        {
            var platoon = Domain.Models.Platoon.CreatePlatoon(request.Name, request.Acronym, request.Commander);

            await _unitOfWork.Repository<Domain.Models.Platoon>().AddAsync(platoon);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ReturnPlatoonViewModel { Id = platoon.Id };
        }
    }
}