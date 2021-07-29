using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Boilerplate.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private IServiceProvider Services { get; set; }

        public QueryDispatcher(IServiceProvider services)
        {
            Services = services;
        }

        public Task<TResult> Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            ValidateQuery(query);
            IQueryHandler<TQuery, TResult> handler = Services.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            ValidateHandler(handler);
            return handler.Handle(query);
        }

        private static void ValidateQuery(IQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
        }

        private static void ValidateHandler(object handler)
        {
            if (handler == null)
            {
                throw new Exception("Failed to execute process, because query handler could not be found. Please register service using dependency injection.");
            }
        }
    }
}