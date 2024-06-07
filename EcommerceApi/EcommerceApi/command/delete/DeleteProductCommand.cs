using MediatR;

namespace EcommerceApi.command.delete
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
