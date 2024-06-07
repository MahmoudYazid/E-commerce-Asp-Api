using EcommerceApi.command;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.model.dbModel
{
    public class DbContext_ :DbContext
    {
        public DbSet<orderModel> orders {  get; set; }
        public DbSet<personModel> Persons{ get; set; }
        public DbSet<productModel> Products { get; set; }
        public DbContext_ (DbContextOptions<DbContext_> options):base(options) { }

    }

}
