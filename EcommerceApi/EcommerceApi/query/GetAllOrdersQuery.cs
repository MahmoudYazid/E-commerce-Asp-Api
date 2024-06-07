using EcommerceApi.model.dbModel;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EcommerceApi.query
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<orderModel>>
    {
        public int id { get; set; }
        public int[] ListOfProductsIds { get; set; }
        public DateTime dateOfOrder { get; set; }
        
        public int ownerId { get; set; }
    
    }
}
