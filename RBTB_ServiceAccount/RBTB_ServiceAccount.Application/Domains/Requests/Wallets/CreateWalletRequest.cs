using MediatR;
using RBTB_ServiceAccount.Application.Domains.Responses.Wallets;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Wallets
{
    public class CreateWalletRequest : IRequest<CreateWalletResponse>
    {
        public Guid UserId { get; set; }

        public string Symbol { get; set; }

        public decimal Balance { get; set; }
    }
}