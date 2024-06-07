using MediatR;

namespace EcommerceApi.command.delete
{
    public class deleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
