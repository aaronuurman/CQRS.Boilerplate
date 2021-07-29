using System.Threading.Tasks;

namespace CQRS.Boilerplate.Query
{
    public interface IQueryDispatcher
    {
        Task<TResult> Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}