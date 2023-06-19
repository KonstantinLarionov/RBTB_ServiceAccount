using MediatR;
using RBTB_ServiceAccount.Application.Domains.Responses.Wallets;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Wallets
{
    public class GetWalletByIdRequest : IRequest<GetWalletByIdResponse>
    {
        public Guid WalletId { get; set; }
    }
}