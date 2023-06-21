using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Users;
using RBTB_ServiceAccount.Application.Domains.Responses.Users;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.User;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    private readonly IRepository<UserEntity> _repositoryUsers;

    public DeleteUserHandler( IRepository<UserEntity> repositoryUsers )
    {
        _repositoryUsers = repositoryUsers;
    }

    public async Task<DeleteUserResponse> Handle( DeleteUserRequest request, CancellationToken cancellationToken )
    {
        var deleteUser = _repositoryUsers.Remove( request.UserId );
        if ( deleteUser == 0 )
        {
            return new DeleteUserResponse() { Success = false };
        }

        return new DeleteUserResponse();
    }
}
