using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.command
{
    public class CreateproductCommand : IRequest<String>
    {

      
        public string Name { get; set; }
        public string desc { get; set; }

        public int ownerId { get; set; }
        public string Image { get; set; }
        public int price { get; set; }


    }
}
