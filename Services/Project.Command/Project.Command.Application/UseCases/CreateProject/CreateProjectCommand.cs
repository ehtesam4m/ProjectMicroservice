using System;
using MediatR;
using Project.Command.Application.Common.Interfaces;

namespace Project.Application.UseCases.Commands.UpdateTaskSchedule
{
    public class CreateProjectCommand : IRequest<ICommandResult>
    {
        public string Name { get; }
        public string ClientName { get; }

        public CreateProjectCommand(string name, string clientName)
        {
            Name = name;
            ClientName = clientName;
        }
    }
}
