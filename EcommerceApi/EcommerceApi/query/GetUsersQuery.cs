using EcommerceApi.model.dbModel;
using MediatR;

namespace EcommerceApi.query
{
    public class GetUsersQuery:IRequest<IEnumerable<personModel>>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string password { get; set; }

    }
}
