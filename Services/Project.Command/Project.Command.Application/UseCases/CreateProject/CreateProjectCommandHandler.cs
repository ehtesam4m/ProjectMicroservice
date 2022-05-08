using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Project.Command.Application.Common.Interfaces;
using Project.Command.Application.EventSourcing;
using Project.Command.Application.Common.Exceptions;
using System;
using Project.Application.Common.Results;

namespace Project.Application.UseCases.Commands.UpdateTaskSchedule
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ICommandResult>
    {
        private readonly IEventSourcingHandler _eventSourcingHandler;
        public CreateProjectCommandHandler(IEventSourcingHandler eventSourcingHandler)
        {
            _eventSourcingHandler = eventSourcingHandler;
        }

        public async Task<ICommandResult> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                throw new ArgumentNullApplicationException(nameof(command));
            }

            var project = new Command.Domain.Aggerates.Project(Guid.NewGuid(), command.Name, command.ClientName);
           
            await _eventSourcingHandler.HandleAsync(project);
            return new CreateCommandSuccessResult();
        }
    }
}
