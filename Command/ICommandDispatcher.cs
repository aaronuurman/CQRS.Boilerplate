using System.Threading.Tasks;

namespace CQRS.Boilerplate.Command
{
    public interface ICommandDispatcher
    {
        Task Execute<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> Execute<TCommand, TResult>(TCommand command) where TCommand : ICommand;
    }
}