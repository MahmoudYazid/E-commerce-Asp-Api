using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.command.create
{
    public class CreateproductCommand : IRequest<string>
    {


        public string Name { get; set; }
        public string desc { get; set; }

        public int ownerId { get; set; }

        public int price { get; set; }
        public IFormFile File { get; set; }


    }
}
