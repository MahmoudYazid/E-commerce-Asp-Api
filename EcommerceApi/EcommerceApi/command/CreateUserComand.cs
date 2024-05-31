using MediatR;

namespace EcommerceApi.command
{
    public class CreateUserComand:IRequest<string>
    {
        public string name { get; set; }
        public string phone { get; set; }


    }
}
