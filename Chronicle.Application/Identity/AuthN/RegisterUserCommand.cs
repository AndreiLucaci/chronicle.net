using Chronicle.Application.Abstractions.Messaging;

namespace Chronicle.Application.Identity.AuthN
{
    public sealed record RegisterUserCommand(string Email, string Password) : ICommand;
}
