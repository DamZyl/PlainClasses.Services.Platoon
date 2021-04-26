using Microsoft.AspNetCore.Mvc;

namespace PlainClasses.Services.Platoon.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatoonController : ControllerBase
    {
        public PlatoonController() { }

        [HttpGet]
        public string Get() => "Platoon Service";
    }
}