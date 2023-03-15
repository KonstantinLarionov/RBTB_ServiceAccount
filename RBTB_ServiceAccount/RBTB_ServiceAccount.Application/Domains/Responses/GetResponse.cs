using RBTB_ServiceAccount.Application.Domains.Entities;

namespace RBTB_ServiceAccount.Application.Domains.Responses;

public class GetResponse:BaseResponse
{
    public Trades Trades { get; set; }
    public Positions Positions { get; set; }
    public Users Users { get; set; }
    public Wallet Wallet { get; set; }
}