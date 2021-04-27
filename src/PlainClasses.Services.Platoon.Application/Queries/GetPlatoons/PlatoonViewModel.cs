using System;

namespace PlainClasses.Services.Platoon.Application.Queries.GetPlatoons
{
    public class PlatoonViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public string Commander { get; set; }
        public int PersonCount { get; set; }
    }
}