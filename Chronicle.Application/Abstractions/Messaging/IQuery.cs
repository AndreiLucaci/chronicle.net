using Chronicle.Domain.Shared;
using MediatR;

namespace Chronicle.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
}
