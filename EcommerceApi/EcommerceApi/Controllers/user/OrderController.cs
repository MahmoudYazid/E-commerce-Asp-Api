using EcommerceApi.command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers.user
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IMediator Mediator_ { get; set; }
        public OrderController(IMediator mediator)
        {
            Mediator_ = mediator;


        }

        [HttpPost]
        public async Task<IActionResult> createOrder(CreateOrderComand command)
        {
            var product = await Mediator_.Send(command);
            return Ok(product);

        }
    }
}
