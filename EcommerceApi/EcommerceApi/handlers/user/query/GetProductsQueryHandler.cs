using EcommerceApi.model.dbModel;
using EcommerceApi.query;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.handlers.user.query
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery ,IEnumerable<productModel>>
    {
        public DbContext_ context_ { get; set; }
        public GetProductsQueryHandler(DbContext_ dbContext_)
        {
            context_ = dbContext_;
        }

        public async Task<IEnumerable<productModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await context_.Products.ToListAsync() ;
        }
    }
}
