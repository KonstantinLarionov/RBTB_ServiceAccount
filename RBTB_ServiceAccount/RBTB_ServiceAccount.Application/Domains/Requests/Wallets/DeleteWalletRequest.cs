using MediatR;
using RBTB_ServiceAccount.Application.Domains.Responses.Wallets;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Wallets
{
    public class DeleteWalletRequest : IRequest<DeleteWalletResponse>
    {
        public Guid WalletId { get; set; }
    }
}