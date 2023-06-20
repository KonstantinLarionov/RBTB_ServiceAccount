using RBTB_ServiceAccount.Client.Common;

namespace RBTB_ServiceAccount.Client.Requests.Wallets
{
    public class DeleteWalletRequest : BaseRequest
    {
        public DeleteWalletRequest( Guid walletId )
        {
            WalletId = walletId;
        }

        public Guid WalletId { get; set; }

        internal override string EndPoint => $"wallets/delete/{WalletId}";

        internal override RequestMethod Method => RequestMethod.DELETE;
    }
}