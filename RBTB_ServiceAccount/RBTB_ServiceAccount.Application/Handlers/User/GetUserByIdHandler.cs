using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Users;
using RBTB_ServiceAccount.Application.Domains.Responses.Users;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.User;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
{
    private readonly IRepository<UserEntity> _repositoryUsers;

    public GetUserByIdHandler( IRepository<UserEntity> repositoryUsers )
    {
        _repositoryUsers = repositoryUsers;
    }

    public async Task<GetUserByIdResponse> Handle( GetUserByIdRequest request, CancellationToken cancellationToken )
    {
        var user = _repositoryUsers.FindById( request.UserId );

        if ( user != null )
        {
            return new GetUserByIdResponse() { Success = false };
        }

        return new GetUserByIdResponse() { Data = user };
    }
}