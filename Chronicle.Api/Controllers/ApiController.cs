using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chronicle.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected readonly ISender Sender;

        public ApiController(ISender sender)
        {
            Sender = sender;
        }
    }
}
