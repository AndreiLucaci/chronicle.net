using Chronicle.Application.Abstractions.Messaging;
using Chronicle.Domain.Identity;

namespace Chronicle.Application.Identity.JWT
{
    public record ComposeJWTTokenCommand(ApplicationUser User) : ICommand<string>;
}
