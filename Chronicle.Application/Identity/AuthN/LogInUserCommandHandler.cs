using Chronicle.Application.Abstractions.Messaging;
using Chronicle.Domain.Identity;
using Chronicle.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Chronicle.Application.Identity.AuthN
{
    public class LogInUserCommandHandler : ICommandHandler<LogInUserCommand, ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogInUserCommandHandler(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Result<ApplicationUser>> Handle(
            LogInUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user is null)
            {
                return new Result<ApplicationUser>(null, "Invalid username or password.");
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(
                user,
                request.Password,
                false
            );

            return signInResult.Succeeded
                ? new Result<ApplicationUser>(user, null)
                : new Result<ApplicationUser>(null, "Invalid username or password.");
        }
    }
}
