using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ValuesController> _logger;
        public ActivitiesController(ILogger<ValuesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        //GET  api/Controller
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> List()
        {
            return await _mediator.Send(new List.Query());
        }

        //GET  Controller/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> Details(Guid id)
        {
            return await _mediator.Send(new Details.Query{Id = id});
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        //PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _mediator.Send(new Delete.Command{Id = id});
        }
    }
}