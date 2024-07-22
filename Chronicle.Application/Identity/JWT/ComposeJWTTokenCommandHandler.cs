using Chronicle.Application.Abstractions.Messaging;
using Chronicle.Domain.Identity;
using Chronicle.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Chronicle.Application.Identity.JWT
{
    public class ComposeJWTTokenCommandHandler : ICommandHandler<ComposeJWTTokenCommand, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenProvider _jwtTokenProvider;

        public ComposeJWTTokenCommandHandler(
            UserManager<ApplicationUser> userManager,
            IJwtTokenProvider jwtTokenProvider
        )
        {
            _userManager = userManager;
            _jwtTokenProvider = jwtTokenProvider;
        }

        public async Task<Result<string>> Handle(
            ComposeJWTTokenCommand request,
            CancellationToken cancellationToken
        )
        {
            var applicationUser = request.User;

            if (applicationUser is null)
            {
                return new Result<string>(null, "User not found.");
            }

            var token = await _jwtTokenProvider.GenerateTokenAsync(applicationUser);

            return new Result<string>(token, null);
        }
    }
}
