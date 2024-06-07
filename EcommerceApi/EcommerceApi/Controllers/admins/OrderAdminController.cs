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
    public class OrderAdminController : ControllerBase
    {
        public IMediator Mediator_ { get; set; }
        public OrderAdminController(IMediator mediator)
        {
            Mediator_ = mediator;


        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> createOrder(CreateOrderComand command)
        {
            var product = await Mediator_.Send(command);
            return Ok(product);

        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var query = new GetAllOrdersQuery();
            var result = await Mediator_.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(deleteOrderCommand query)
        {
         
            var result = await Mediator_.Send(query);
            return Ok(result);
        }
    }
}
