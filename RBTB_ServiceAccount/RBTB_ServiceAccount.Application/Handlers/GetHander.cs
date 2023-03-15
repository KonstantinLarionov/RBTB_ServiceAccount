using MediatR;
using RBTB_ServiceAccount.Application.Domains.Request;
using RBTB_ServiceAccount.Application.Domains.Responses;

namespace RBTB_ServiceAccount.Application.Handlers;

public class GetHander:IRequestHandler<GetRequest,GetResponse>
{
    public Task<GetResponse> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}