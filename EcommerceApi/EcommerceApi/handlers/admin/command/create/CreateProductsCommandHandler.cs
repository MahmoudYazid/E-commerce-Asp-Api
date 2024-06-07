using EcommerceApi.command.create;
using EcommerceApi.model.dbModel;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.handlers.admin.command.create
{
    public class CreateProductsCommandHandler : IRequestHandler<CreateproductCommand, string>
    {
        public DbContext_ context_ { get; set; }
        private readonly IWebHostEnvironment _environment;
        public CreateProductsCommandHandler(DbContext_ dbContext_, IWebHostEnvironment environment)
        {
            context_ = dbContext_;
            _environment = environment;
        }

        public async Task<string> Handle(CreateproductCommand request, CancellationToken cancellationToken)
        {

            var findIdOfUser = await context_.Persons.FirstOrDefaultAsync(x => x.id == request.ownerId);
            if (findIdOfUser != null)
            {
                productModel productModel_ = new productModel
                {
                    Name = request.Name,
                    desc = request.desc,
                    price = request.price,

                    ownerId = request.ownerId,

                };
                string GetExtentionOfFile = Path.GetExtension(request.File.FileName);
                string newName = Path.GetFileNameWithoutExtension(request.File.FileName) + Directory.EnumerateFiles("C:\\Users\\ahmed\\Desktop\\GIT\\E-commerce-Asp-Api\\EcommerceApi\\EcommerceApi\\uploadedPhoto\\").Count().ToString() + GetExtentionOfFile;
                var filePath = Path.Combine("C:\\Users\\ahmed\\Desktop\\GIT\\E-commerce-Asp-Api\\EcommerceApi\\EcommerceApi\\uploadedPhoto\\", newName);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.File.CopyToAsync(stream);
                }



                productModel_.Image = filePath;

                context_.Products.Add(productModel_);
                context_.SaveChangesAsync();
                return "Product created";
            }
            else
            {
                return "the user is not exist in the database";
            }



        }
    }
}
