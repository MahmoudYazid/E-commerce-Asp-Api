using MediatR;

namespace EcommerceApi.query
{
    public class LoginQuery:IRequest<string>
    {
        public string name { get; set; }
        
        public string password { get; set; }
    }
}
