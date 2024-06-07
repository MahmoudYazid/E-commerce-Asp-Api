using EcommerceApi.command.create;
using EcommerceApi.model.dbModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.handlers.admin.command.create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserComand, string>
    {
        public DbContext_ context_ { get; set; }
        public CreateUserCommandHandler(DbContext_ dbContext_)
        {
            context_ = dbContext_;
        }
        public async Task<string> Handle(CreateUserComand request, CancellationToken cancellationToken)
        {
            var checkExistUser = await context_.Persons.FirstOrDefaultAsync(x => x.name == request.name);
            if (checkExistUser == null)
            {
                var newPersonInst = new personModel { name = request.name, phone = request.phone , password = request.password};
                context_.Persons.Add(newPersonInst);
                context_.SaveChangesAsync();
                return "user created";

            }
            else
            {
                return "Name used before";
            }
        }
    }
}
