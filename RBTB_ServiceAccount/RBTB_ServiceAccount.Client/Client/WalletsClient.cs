using RBTB_ServiceAccount.Abstractions.Models;
using RBTB_ServiceAccount.Client.Common;
using RBTB_ServiceAccount.Client.Requests.Wallets;
using RestSharp;

namespace RBTB_ServiceAccount.Client.Client
{
    public class WalletsClient
    {
        private readonly IRestClient _client;

        public WalletsClient( IRestClient client ) 
        {
            _client = client;
        }

        public BaseResponse<Guid> CreateWallet( Guid userId, string symbol, decimal balance )
        {
            var request = new CreateWalletRequest( userId, symbol, balance );

            var response = new BaseSendRequest<Guid>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<Guid> DeleteWallet( Guid walletId )
        {
            var request = new DeleteWalletRequest( walletId );

            var response = new BaseSendRequest<Guid>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<Wallet> GetWalletById( Guid walletId )
        {
            var request = new GetWalletByIdRequest( walletId );

            var response = new BaseSendRequest<Wallet>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<List<Wallet>> GetWallets( Guid? userId, string? symbol )
        {
            var request = new GetWalletsRequest( userId, symbol );

            var response = new BaseSendRequest<List<Wallet>>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<Wallet> UpdateWallet( Guid id, Guid userId, string symbol, decimal balance )
        {
            var request = new UpdateWalletRequest( id, userId, symbol, balance );

            var response = new BaseSendRequest<Wallet>().SendRequest( _client, request );

            return response;
        }
    }
}