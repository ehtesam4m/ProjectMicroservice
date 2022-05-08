using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Common.Results;
using Project.Command.Application.Common.Interfaces;
using Project.Common.Application.Common.Results;

namespace Project.Command.API.Common
{
    public static class Output
    {
        public static IActionResult For(ICommandResult output) =>
            output switch
            {
                CreateCommandSuccessResult _ => new NoContentResult(),
                RequestEntryNotFoundResult _ => new NotFoundResult(),
                _ => new StatusCodeResult(StatusCodes.Status500InternalServerError)
            };
    }
}
