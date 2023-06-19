using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Users;
using RBTB_ServiceAccount.Application.Domains.Responses.Users;
using RBTB_ServiceAccount.Database.Entities;
using RBTB_ServiceAccount.Database.Repositories;

namespace RBTB_ServiceAccount.Application.Handlers.User;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly IRepository<UserEntity> _repositoryUsers;

    public UpdateUserHandler( IRepository<UserEntity> repositoryUsers )
    {
        _repositoryUsers = repositoryUsers;
    }

    public async Task<UpdateUserResponse> Handle( UpdateUserRequest request, CancellationToken cancellationToken )
    {
        var user = new UserEntity()
        {
            Id = request.Id,
            CreatedDate = request.CreatedDate,
            Login = request.Login,
            Password = request.Password,
            RefferalFrom = request.RefferalFrom,
            Username = request.Username
        };

        var createUser = _repositoryUsers.Create( user );
        if ( createUser == 0 )
        {
            return new UpdateUserResponse() { Success = false };
        }

        return new UpdateUserResponse();
    }
}