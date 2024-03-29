using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Users;
using RBTB_ServiceAccount.Application.Domains.Responses.Users;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

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

        var updateUser = _repositoryUsers.Update( user );
        if ( updateUser == 0 )
        {
            return new UpdateUserResponse() { Success = false };
        }

        return new UpdateUserResponse() { Data = user };
    }
}