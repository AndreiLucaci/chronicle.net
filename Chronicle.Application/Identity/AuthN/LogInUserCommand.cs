using Chronicle.Application.Abstractions.Messaging;
using Chronicle.Domain.Identity;

namespace Chronicle.Application.Identity.AuthN
{
    public record LogInUserCommand(string Username, string Password) : ICommand<ApplicationUser>;
}
