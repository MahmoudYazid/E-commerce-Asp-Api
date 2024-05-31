using EcommerceApi.command;
using EcommerceApi.query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers.user
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IMediator Mediator_ { get; set; }
        public ProductsController( IMediator mediator ) {
            Mediator_= mediator;


        }
        [HttpPost]
        public async Task<IActionResult> createProduct(CreateproductCommand command) {
            var product = await Mediator_.Send(command);
            return Ok(product);
        
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var getAllProducts = new GetProductsQuery();
            var product = await Mediator_.Send(getAllProducts);
            return Ok(product);

        }
    }
}
