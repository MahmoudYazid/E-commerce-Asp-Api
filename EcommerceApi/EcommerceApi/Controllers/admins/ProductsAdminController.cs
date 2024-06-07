using EcommerceApi.command.create;
using EcommerceApi.command.delete;
using EcommerceApi.query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers.admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsAdminController : ControllerBase
    {
        public IMediator Mediator_ { get; set; }
        public ProductsAdminController(IMediator mediator)
        {
            Mediator_ = mediator;


        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> createProduct([FromForm] CreateproductCommand command)
        {
            var product = await Mediator_.Send(command);
            return Ok(product);

        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var getAllProducts = new GetProductsQuery();
            var product = await Mediator_.Send(getAllProducts);
            return Ok(product);

        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand DeleteProductsCommand)
        {
           
            var product = await Mediator_.Send(DeleteProductsCommand);
            return Ok(product);

        }
    }
}
