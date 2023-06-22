using RestSharp;

namespace RBTB_ServiceAccount.Client.Client
{
    public class ServiceAccountClient
    {
        public ServiceAccountClient(string baseUrl) 
        {
            IRestClient client = new RestClient( baseUrl );
            Positions = new PositionsClient(client);
            Trades = new TradesClient( client );
            Users = new UsersClient( client );
            Wallets = new WalletsClient( client );
        }

        public PositionsClient Positions { get; }

        public TradesClient Trades { get; }

        public UsersClient Users { get; }

        public WalletsClient Wallets { get; }
    }
}
