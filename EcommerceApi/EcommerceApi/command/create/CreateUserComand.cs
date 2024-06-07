using MediatR;

namespace EcommerceApi.command.create
{
    public class CreateUserComand : IRequest<string>
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string password { get; set; }

    }
}
