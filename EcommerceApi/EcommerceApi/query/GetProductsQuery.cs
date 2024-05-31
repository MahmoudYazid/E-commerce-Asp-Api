using EcommerceApi.model.dbModel;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.query
{
    public class GetProductsQuery : IRequest<IEnumerable<productModel>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string desc { get; set; }
        
        public int ownerId { get; set; }
        public string Image { get; set; }
        public int price { get; set; }
    }
}
