using MediatR;
using RBTB_ServiceAccount.Application.Domains.Responses.Wallets;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Wallets
{
    public class GetWalletsRequest : IRequest<GetWalletsResponse>
    {
        public Guid? UserId { get; set; }

        public string? Symbol { get; set; }

        public DateTime DateBegin { get; set; }

        public DateTime? DateEnd { get; set; }
        public string? Market { get; set; }
    }
}