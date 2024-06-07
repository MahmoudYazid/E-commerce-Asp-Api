using EcommerceApi.config;
using EcommerceApi.model.dbModel;
using EcommerceApi.query;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceApi.handlers.admin.query
{
    public class LoginCommandHandler : IRequestHandler<LoginQuery, string>
    {
        public DbContext_ context_ { get; set; }
        public JwtSettings jwtSettings_ { get; set; }
        public LoginCommandHandler(DbContext_ dbContext_, JwtSettings jwtSettings)
        {
            context_ = dbContext_;
            jwtSettings_ = jwtSettings;
        }
        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var verify = await context_.Persons.FirstOrDefaultAsync(x => x.name == request.name && x.password == request.password, cancellationToken);
            
            if (verify != null)
            {
               
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings_.Key));
                var credintial = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var Claims = new[] {
                    new Claim( ClaimTypes.NameIdentifier, request.name)


                };

                var newToken = new JwtSecurityToken(
                    jwtSettings_.Issuer,
                    jwtSettings_.Audience,
                    claims: Claims,
                    expires : DateTime.Now.AddMinutes(2),
                    signingCredentials : credintial


                    );

                return new JwtSecurityTokenHandler().WriteToken(newToken);
            }
            else
            {

                return "there is no user that name and password";

            }


        }

        
    }
}
