using EcommerceApi.model.dbModel;
using EcommerceApi.query;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.handlers.admin.query
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery , IEnumerable<orderModel>>
    {
        public DbContext_ context_ { get; set; }
        public GetAllOrdersQueryHandler(DbContext_ dbContext_)
        {
            context_ = dbContext_;
        }

        public async Task<IEnumerable<orderModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await context_.orders.ToListAsync();
        }
    }
}
