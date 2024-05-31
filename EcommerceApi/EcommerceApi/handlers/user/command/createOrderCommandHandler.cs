using EcommerceApi.command;
using EcommerceApi.model.dbModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.handlers.user.command
{
    public class createOrderCommandHandler:IRequestHandler<CreateOrderComand , string>
    {
        public DbContext_ context_ { get; set; }
        public createOrderCommandHandler(DbContext_ dbContext_)
        {
            context_ = dbContext_;
        }

        public async Task<string> Handle(CreateOrderComand request, CancellationToken cancellationToken)
        {
            try
            {
                var findIdOfUser = await context_.Persons.FirstOrDefaultAsync(x => x.id == request.ownerId);
                if (findIdOfUser != null)
                {
                    var newOrder = new orderModel
                    {
                        ListOfProductsIds = request.ListOfProductsIds,
                        ownerId = request.ownerId,
                        dateOfOrder = DateTime.Now



                    };
                    var newProductOrder = context_.orders.Add(newOrder);
                    context_.SaveChangesAsync();
                    return "order has been established";

                }
                else {
                    return "user not finded";

                }
                   
            }
            catch {
                return "order not established";
            }
           
        }
    }
}
