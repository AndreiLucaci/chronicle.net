using Chronicle.Domain.Shared;
using MediatR;

namespace Chronicle.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result> { }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }
}
