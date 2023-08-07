using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Domains.Requests.Users;
using RBTB_ServiceAccount.Application.Domains.Responses.Users;
using RBTB_ServiceAccount.Application.Inerfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceAccount.Application.Handlers.User
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest,LoginUserResponse>
    {
        private readonly IRepository<UserEntity> _repositoryUsers;

        public LoginUserHandler(IRepository<UserEntity> repositoryUsers)
        {
            _repositoryUsers = repositoryUsers;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var login = request.Login;
            var password = CalculateSHA256(request.Password);
            var user = _repositoryUsers.Get().Where(u => u.Login == login && u.Password == password);
            if (user == null)
            {
                return new LoginUserResponse() { Success = false };
            }
            else
            {
                var token = GetToken(login);
                return new LoginUserResponse() { Success = true  ,Token=token };
            }
        }
        private string CalculateSHA256(string s)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

                return BitConverter.ToString(hashValue).Replace("-", "").ToUpper();
            }
        }
        private string GetToken(string login)
        {   
            var identity = GetClimes(login);
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: JWTResources.ISSUER,
                    audience: JWTResources.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(double.Parse(JWTResources.LIFETIME))),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTResources.KEY)), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return JsonConvert.SerializeObject(response);
        }
        private ClaimsIdentity GetClimes(string login) //TODO сделать клаймы
        {           
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, login)                    
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;            
        }        
    }
}
