using Chronicle.Application.Abstractions.Messaging;
using Chronicle.Domain.Identity;
using Chronicle.Domain.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

namespace Chronicle.Application.Identity.AuthN
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public RegisterUserCommandHandler(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Result> Handle(
            RegisterUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = new ApplicationUser { UserName = request.Email, Email = request.Email };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(
                    user,
                    request.Password,
                    false
                );
                return signInResult.Succeeded
                    ? Result.Success
                    : Result.Failure("Failed to sign in the user.");
            }

            return Result.Failure(
                string.Join(',', result.Errors.Select(x => x.Description))
                    ?? "An error occurred while registering the user."
            );
        }
    }
}
