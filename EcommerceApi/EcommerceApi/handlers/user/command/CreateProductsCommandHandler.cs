using EcommerceApi.command;
using EcommerceApi.model.dbModel;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.handlers.user.command
{
    public class CreateProductsCommandHandler : IRequestHandler<CreateproductCommand, String>
    {
        public DbContext_ context_ { get; set; }
        public CreateProductsCommandHandler(DbContext_ dbContext_)
        {
            context_ = dbContext_;
        }

        public async Task<String> Handle(CreateproductCommand request, CancellationToken cancellationToken)
        {
            var findIdOfUser = await context_.Persons.FirstOrDefaultAsync(x => x.id == request.ownerId);
            if (findIdOfUser != null)
            {
                productModel productModel_ = new productModel
                {
                    Name = request.Name,
                    desc = request.desc,
                    price = request.price,
                    Image = request.Image,
                    ownerId = request.ownerId,

                };

                context_.Products.Add(productModel_);
                context_.SaveChangesAsync();
                return "Product created";
            }
            else
            {
                return "the user is not exist in the database";
            }



        }
    }
}
