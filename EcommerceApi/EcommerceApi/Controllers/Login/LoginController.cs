using EcommerceApi.model.dbModel;
using EcommerceApi.query;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceApi.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IMediator Mediator_ { get; set; }
        public LoginController(IMediator mediator)
        {
            Mediator_ = mediator;


        }
        // GET: api/<LoginController>
        [HttpPost]
        public async Task<IActionResult> Login(LoginQuery loginQuery)
        {
            var result = await Mediator_.Send(loginQuery);

            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized("Invalid username or password");
        }


    }
}
