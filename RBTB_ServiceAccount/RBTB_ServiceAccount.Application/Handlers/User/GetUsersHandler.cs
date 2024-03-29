using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Users;
using RBTB_ServiceAccount.Application.Domains.Responses.Users;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.User;

public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
{
    private readonly IRepository<UserEntity> _repositoryUsers;

    public GetUsersHandler( IRepository<UserEntity> repositoryUsers )
    {
        _repositoryUsers = repositoryUsers;
    }

    public async Task<GetUsersResponse> Handle( GetUsersRequest request, CancellationToken cancellationToken )
    {
        var users = _repositoryUsers.Get();

        if ( !users.Any() )
        {
            return new GetUsersResponse();
        }

        return new GetUsersResponse() { Data = users.ToArray() };
    }
}
