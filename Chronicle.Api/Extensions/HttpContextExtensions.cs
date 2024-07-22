using Chronicle.Domain.JWT;

namespace Chronicle.Api.Extensions
{
    public static class HttpContextExtensions
    {
        public static string? GetCurrentUsername(this HttpContext httpContext)
        {
            var username = httpContext
                .User?.Claims?.FirstOrDefault(x => x.Type == KnownClaims.Username)
                ?.Value;

            return username;
        }
    }
}
