using EcommerceApi.model.dbModel;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EcommerceApi.command.create
{
    public class CreateOrderComand : IRequest<string>
    {

        public int[] ListOfProductsIds { get; set; }
        public DateTime dateOfOrder { get; set; } = DateTime.Now;
        public int ownerId { get; set; }

    }
}
