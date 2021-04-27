using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlainClasses.Services.Platoon.Api.Controllers.Requests;
using PlainClasses.Services.Platoon.Application.Commands.AddPerson;
using PlainClasses.Services.Platoon.Application.Commands.CreatePlatoon;
using PlainClasses.Services.Platoon.Application.Commands.DeletePerson;
using PlainClasses.Services.Platoon.Application.Commands.DeletePlatoon;
using PlainClasses.Services.Platoon.Application.Commands.UpdatePlatoon;
using PlainClasses.Services.Platoon.Application.Queries.GetPlatoon;
using PlainClasses.Services.Platoon.Application.Queries.GetPlatoons;

namespace PlainClasses.Api.Platoons
{
    [Route("api/platoons")]
    [ApiController]
    public class PlatoonController : Controller
    {
        private readonly IMediator _mediator;

        public PlatoonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PlatoonViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPlatoons()
        {
            var platoons = await _mediator.Send(new GetPlatoonsQuery());

            return Ok(platoons);
        }
        
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(PlatoonDetailViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPlatoon(Guid id)
        {
            var platoon = await _mediator.Send(new GetPlatoonQuery { Id = id });

            return Ok(platoon);
        }
        
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(ReturnPlatoonViewModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreatePlatoon([FromBody]CreatePlatoonRequest request) 
        {
            var platoon = await _mediator.Send(new CreatePlatoonCommand(request.Name, request.Acronym, request.Commander));

            return Created(string.Empty, platoon);
        }
        
        [Route("{id}/person/{personId}")]
        [HttpPost]
        [ProducesResponseType(typeof(ReturnPlatoonViewModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddPersonToPlatoon(Guid id, Guid personId)
        {
            var platoon = await _mediator.Send(new AddPersonCommand(id, personId));

            return Created(string.Empty, platoon);
        }
        
        [Route("{id}")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> UpdatePlatoon(Guid id, [FromBody]UpdatePlatoonRequest request)
        {
            await _mediator.Send(new UpdatePlatoonCommand(id, request.Commander));

            return NoContent();
        }
        
        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeletePlatoon(Guid id)
        {
            await _mediator.Send(new DeletePlatoonCommand(id));

            return NoContent();
        }
        
        [Route("{id}/person/{personId}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeletePersonFromPlatoon(Guid id, Guid personId)
        {
            await _mediator.Send(new DeletePersonFromPlatoonCommand(id, personId));

            return NoContent();
        }
    }
}