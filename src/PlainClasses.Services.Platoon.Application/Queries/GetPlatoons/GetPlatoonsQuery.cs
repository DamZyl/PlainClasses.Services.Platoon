using System.Collections.Generic;
using MicroserviceLibrary.Application.Configurations.Dispatchers;

namespace PlainClasses.Services.Platoon.Application.Queries.GetPlatoons
{
    public class GetPlatoonsQuery : IQuery<IEnumerable<PlatoonViewModel>> { }
}