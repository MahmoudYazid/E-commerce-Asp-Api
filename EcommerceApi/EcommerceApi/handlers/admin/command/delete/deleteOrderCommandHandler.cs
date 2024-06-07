using EcommerceApi.command.delete;
using EcommerceApi.model.dbModel;
using MediatR;

namespace EcommerceApi.handlers.admin.command.delete
{
    public class deleteOrderCommandHandler : IRequestHandler<deleteOrderCommand, int>
    {
        public DbContext_ context_ { get; set; }
        public deleteOrderCommandHandler(DbContext_ dbContext_)
        {
            context_ = dbContext_;
        }

        public async Task<int> Handle(deleteOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var findobj = context_.orders.FirstOrDefault(finditem => finditem.id == request.Id);
                var deleteOrder = context_.orders.Remove(findobj);
                await context_.SaveChangesAsync();
                return 1;
            }
            catch { 
                return 0;
            
            }
           
        }
    }
}
