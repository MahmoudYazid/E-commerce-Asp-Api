using EcommerceApi.model.dbModel;
using EcommerceApi.query;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.handlers.user.query
{
    public class GetUserQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<personModel>>
    {
        public DbContext_ context_ { get; set; }
        public GetUserQueryHandler(DbContext_ dbContext_)
        {
            context_ = dbContext_;
        }

        public async Task<IEnumerable<personModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await context_.Persons.ToListAsync();
        }
    }
}
