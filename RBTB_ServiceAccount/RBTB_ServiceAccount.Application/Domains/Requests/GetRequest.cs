using MediatR;
using RBTB_ServiceAccount.Application.Domains.Responses;

namespace RBTB_ServiceAccount.Application.Domains.Request;

public class GetRequest:IRequest<GetResponse>
{
    public Guid idTrades { get; set; }
    public Guid idPositions { get; set; }
    public Guid idUsers { get; set; }
    public Guid idWallet { get; set; }
}