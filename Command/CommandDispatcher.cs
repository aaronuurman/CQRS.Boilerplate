using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Boilerplate.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private IServiceProvider Services { get; init; }

        public CommandDispatcher(IServiceProvider services)
        {
            Services = services;
        }

        public async Task Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            ValidateCommand(command);
            ICommandHandler<TCommand> handler = Services.GetRequiredService<ICommandHandler<TCommand>>();
            ValidateHandler(handler);
            await handler.Handle(command);
        }

        public async Task<TResult> Execute<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            ValidateCommand(command);
            ICommandHandler<TCommand, TResult> handler = Services.GetRequiredService<ICommandHandler<TCommand, TResult>>();
            ValidateHandler(handler);
            return await handler.Handle(command);
        }

        private static void ValidateCommand(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
        }

        private static void ValidateHandler(object handler)
        {
            if (handler == null)
            {
                throw new Exception("Failed to execute process, because command handler could not be found. Please register service using dependency injection.");
            }
        }
    }
}