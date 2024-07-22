using Chronicle.Api.DTOs;
using Chronicle.Api.Extensions;
using Chronicle.Application.Identity.AuthN;
using Chronicle.Application.Identity.JWT;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chronicle.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ApiController
    {
        public AccountController(ISender sender)
            : base(sender) { }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            [FromBody] RegisterUserRequestDto requestBody,
            CancellationToken cancellationToken
        )
        {
            var command = new RegisterUserCommand(requestBody.Email, requestBody.Password);

            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LogInUserRequestDto requestDto,
            CancellationToken cancellationToken
        )
        {
            var command = new LogInUserCommand(requestDto.Email, requestDto.Password);
            var applicationUserResponse = await Sender.Send(command, cancellationToken);

            if (!applicationUserResponse.IsSuccess)
            {
                return Unauthorized(applicationUserResponse.Error);
            }

            var token = await Sender.Send(
                new ComposeJWTTokenCommand(applicationUserResponse.Value),
                cancellationToken
            );

            return token.IsSuccess ? Ok(token.Value) : Unauthorized(token.Error);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AuthenticatedGet()
        {
            return Ok($"Hello, {HttpContext.GetCurrentUsername()}! You have access.");
        }
    }
}
