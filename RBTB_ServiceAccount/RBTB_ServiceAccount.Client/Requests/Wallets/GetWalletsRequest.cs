using RBTB_ServiceAccount.Client.Common;
using RBTB_ServiceAccount.Client.Extensions;

namespace RBTB_ServiceAccount.Client.Requests.Wallets
{
    public class GetWalletsRequest : BaseRequest
    {
        public GetWalletsRequest( Guid userId, string symbol )
        {
            UserId = userId;
            Symbol = symbol;
        }

        public Guid UserId { get; set; }

        public string Symbol { get; set; }

        internal override string EndPoint => "wallets";

        internal override RequestMethod Method => RequestMethod.GET;

        internal override IDictionary<string, string> Properties
        {
            get
            {
                var res = new Dictionary<string, string>();

                res.AddSimpleStruct( "userId", UserId );
                res.Add( "symbol", Symbol );

                return res;
            }
        }
    }
}