using RBTB_ServiceAccount.Client.Common;

namespace RBTB_ServiceAccount.Client.Requests.Wallets
{
    public class GetWalletByIdRequest : BaseRequest
    {
        public GetWalletByIdRequest( Guid walletId )
        {
            WalletId = walletId;
        }

        public Guid WalletId { get; set; }

        internal override string EndPoint => $"wallets/{WalletId}";

        internal override RequestMethod Method => RequestMethod.GET;
    }
}