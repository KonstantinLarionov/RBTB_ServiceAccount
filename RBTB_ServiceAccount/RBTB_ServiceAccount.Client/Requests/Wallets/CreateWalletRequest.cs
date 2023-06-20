using RBTB_ServiceAccount.Client.Common;
using RBTB_ServiceAccount.Client.Extensions;

namespace RBTB_ServiceAccount.Client.Requests.Wallets
{
    public class CreateWalletRequest : BaseRequest
    {
        public CreateWalletRequest( Guid userId, string symbol, decimal balance )
        {
            UserId = userId;
            Symbol = symbol;
            Balance = balance;
        }

        public Guid UserId { get; set; }

        public string Symbol { get; set; }

        public decimal Balance { get; set; }

        internal override string EndPoint => "wallets/create";

        internal override RequestMethod Method => RequestMethod.POST;

        internal override IDictionary<string, string> Properties
        {
            get
            {
                var res = new Dictionary<string, string>();

                res.AddSimpleStruct( "userId", UserId );
                res.Add( "symbol", Symbol );
                res.AddDecimal( "balance", Balance );

                return res;
            }
        }
    }
}