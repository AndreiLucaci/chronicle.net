using Chronicle.Domain.Shared;
using MediatR;

namespace Chronicle.Application.Abstractions.Messaging
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse> { }
}
