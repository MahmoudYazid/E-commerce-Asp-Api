using EcommerceApi.command;
using EcommerceApi.query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers.user
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        public IMediator Mediator_ { get; set; }
        public userController(IMediator mediator)
        {
            Mediator_ = mediator;


        }

        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserComand createUser) {
            var newuser = await Mediator_.Send(createUser);
            return Ok(newuser);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var query = new GetUsersQuery();
            var users = await Mediator_.Send(query);
            return Ok(users);
        }
    }
}
