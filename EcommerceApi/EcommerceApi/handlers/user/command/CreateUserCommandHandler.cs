using EcommerceApi.command;
using EcommerceApi.model.dbModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.handlers.user.command
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
                var newPersonInst = new personModel { name = request.name, phone = request.phone };
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
