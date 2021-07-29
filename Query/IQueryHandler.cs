using System.Threading.Tasks;

namespace CQRS.Boilerplate.Query
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> Handle(TQuery query);
    }
}