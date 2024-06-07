using EcommerceApi.command.delete;
using EcommerceApi.model.dbModel;
using MediatR;

namespace EcommerceApi.handlers.admin.command.delete
{
    public class deleteUserCommandHandler : IRequestHandler<deleteUserCommand , int>
    {
        public DbContext_ context_ { get; set; }
        public deleteUserCommandHandler(DbContext_ dbContext_)
        {
            context_ = dbContext_;
        }

        public async Task<int> Handle(deleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var findobj = context_.Persons.FirstOrDefault(finditem => finditem.id == request.Id);
                if (findobj == null)
                {
                    return 0; // Or appropriate error code if the object is not found
                }

                context_.Persons.Remove(findobj);
                await context_.SaveChangesAsync(cancellationToken);
                return 1;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return 0;
            }
        }
    }
}
