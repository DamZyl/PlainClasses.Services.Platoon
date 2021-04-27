using System.Collections.Generic;
using PlainClasses.Services.Platoon.Application.Queries.GetPlatoons;

namespace PlainClasses.Services.Platoon.Application.Queries.GetPlatoon
{
    public class PlatoonDetailViewModel : PlatoonViewModel
    {
        public List<PersonForPlatoonViewModel> Persons { get; set; }
    }
}