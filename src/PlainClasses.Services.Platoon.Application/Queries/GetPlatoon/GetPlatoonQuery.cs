using System;
using MicroserviceLibrary.Application.Configurations.Dispatchers;

namespace PlainClasses.Services.Platoon.Application.Queries.GetPlatoon
{
    public class GetPlatoonQuery : IQuery<PlatoonDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}