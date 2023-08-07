using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Users;
using RBTB_ServiceAccount.Application.Domains.Responses.Users;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;
using System.Security.Cryptography;
using System.Text;

namespace RBTB_ServiceAccount.Application.Handlers.User;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IRepository<UserEntity> _repositoryUsers;

    public CreateUserHandler( IRepository<UserEntity> repositoryUsers )
    {
        _repositoryUsers = repositoryUsers;
    }

    public async Task<CreateUserResponse> Handle( CreateUserRequest request, CancellationToken cancellationToken )
    {
        var user = new UserEntity()
        {
            Id = Guid.NewGuid(),
            CreatedDate = request.CreatedDate,
            Login = request.Login,
            Password = CalculateSHA256(request.Password),
            RefferalFrom = request.RefferalFrom,
            Username = request.Username
        };

        var createUser = _repositoryUsers.Create( user );
        if ( createUser == 0 )
        {
            return new CreateUserResponse() { Success = false };
        }

        return new CreateUserResponse() { Data = user.Id };

        string CalculateSHA256(string s)
        {
            using (SHA256 sha256 = SHA256.Create())
            {                
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
                
                return BitConverter.ToString(hashValue).Replace("-", "").ToUpper();
            }
        }
    }
}
