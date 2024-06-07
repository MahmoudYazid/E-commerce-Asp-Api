using EcommerceApi.command.create;
using EcommerceApi.command.delete;
using EcommerceApi.query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers.admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class userAdminController : ControllerBase
    {
        public IMediator Mediator_ { get; set; }
        public userAdminController(IMediator mediator)
        {
            Mediator_ = mediator;


        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserComand createUser)
        {
            var newuser = await Mediator_.Send(createUser);
            return Ok(newuser);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var query = new GetUsersQuery();
            var users = await Mediator_.Send(query);
            return Ok(users);
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteUsers(deleteUserCommand query )
        {

            var users = await Mediator_.Send(query);
            return Ok(users);
        }
    }
}
