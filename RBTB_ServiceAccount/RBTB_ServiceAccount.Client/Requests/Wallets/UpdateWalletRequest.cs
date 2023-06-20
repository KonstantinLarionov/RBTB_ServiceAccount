using RBTB_ServiceAccount.Client.Common;
using RBTB_ServiceAccount.Client.Extensions;

namespace RBTB_ServiceAccount.Client.Requests.Wallets
{
    public class UpdateWalletRequest : BaseRequest
    {
        public UpdateWalletRequest( Guid id, Guid userId, string symbol, decimal balance )
        {
            Id = id;
            UserId = userId;
            Symbol = symbol;
            Balance = balance;
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Symbol { get; set; }

        public decimal Balance { get; set; }

        internal override string EndPoint => "wallets/update";

        internal override RequestMethod Method => RequestMethod.PUT;

        internal override IDictionary<string, string> Properties
        {
            get
            {
                var res = new Dictionary<string, string>();

                res.AddSimpleStruct( "id", Id );
                res.AddSimpleStruct( "userId", UserId );
                res.Add( "symbol", Symbol );
                res.AddDecimal( "balance", Balance );

                return res;
            }
        }
    }
}