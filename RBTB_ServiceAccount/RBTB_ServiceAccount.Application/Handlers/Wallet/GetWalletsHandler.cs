using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Users;
using RBTB_ServiceAccount.Application.Domains.Responses.Users;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.Wallet;

public class GetWalletsHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
{
    private readonly IRepository<UserEntity> _repositoryUsers;

    public GetWalletsHandler( IRepository<UserEntity> repositoryUsers )
    {
        _repositoryUsers = repositoryUsers;
    }

    public async Task<GetUsersResponse> Handle( GetUsersRequest request, CancellationToken cancellationToken )
    {
        var users = _repositoryUsers.Get();

        if ( !users.Any() )
        {
            return new GetUsersResponse() { Success = false };
        }

        return new GetUsersResponse() { Data = users.ToArray() };
    }
}
