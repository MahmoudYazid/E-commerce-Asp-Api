using EcommerceApi.command.delete;
using EcommerceApi.model.dbModel;
using MediatR;

namespace EcommerceApi.handlers.admin.command.delete
{
    public class deleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        public DbContext_ context_ { get; set; }
        public deleteProductCommandHandler(DbContext_ dbContext_)
        {
            context_ = dbContext_;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var findobj = context_.Products.FirstOrDefault(finditem => finditem.Id == request.Id);
                var deleteOrder = context_.Products.Remove(findobj);
                await context_.SaveChangesAsync();
                return 1;
            }
            catch {
                return 0;
            }
           
        }
    }
}
