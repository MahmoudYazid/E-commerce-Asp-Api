using MediatR;

namespace EcommerceApi.command.delete
{
    public class deleteOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
