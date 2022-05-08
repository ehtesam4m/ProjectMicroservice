using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.API.UseCases.Commands.CreateProject;
using Project.Application.UseCases.Commands.UpdateTaskSchedule;
using Project.Command.API.Common;

namespace Project.Command.API.UseCases.CreateProject
{
    [Route("project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(typeof(NoContentResult), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTaskSchedule([FromBody] CreateProjectRequest createProjectRequest)
        {
            var commandResult = await _mediator.Send(new CreateProjectCommand(createProjectRequest.Name, createProjectRequest.ClientName));
            return Output.For(commandResult);
        }
    }
}
