using System;
using System.Threading.Tasks;
using MicroserviceLibrary.Domain.SharedKernels;

namespace PlainClasses.Services.Platoon.Domain.Models.DomainServices
{
    public interface IGetPlatoonForId : IDomainService
    {
        Platoon Get(Guid platoonId);
        Task<Platoon> GetAsync(Guid platoonId);
        Task<Platoon> GetDetailAsync(Guid platoonId);
    }
}