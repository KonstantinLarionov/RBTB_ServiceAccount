using RBTB_ServiceAccount.Abstractions.Models;
using RBTB_ServiceAccount.Client.Abstractions.Enums;
using RBTB_ServiceAccount.Client.Common;
using RBTB_ServiceAccount.Client.Requests.Trades;
using RestSharp;

namespace RBTB_ServiceAccount.Client.Client
{
    public class TradesClient
    {
        private readonly IRestClient _client;

        public TradesClient( IRestClient client ) 
        {
            _client = client;
        }

        public BaseResponse<Guid> CreateTrade( Guid userId,
            decimal price,
            decimal count,
            OrderType orderType,
            Side side,
            string symbol,
            OrderStatus orderStatus,
            TimeInForce timeInForce,
            DateTime createdDate )
        {
            var request = new CreateTradeRequest( userId,
                price,
                count,
                orderType,
                side,
                symbol,
                orderStatus,
                timeInForce,
                createdDate );

            var response = new BaseSendRequest<Guid>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<Guid> DeleteTrade( Guid tradeId )
        {
            var request = new DeleteTradeRequest( tradeId );

            var response = new BaseSendRequest<Guid>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<Trade> GetTradeById( Guid tradeId )
        {
            var request = new GetTradeByIdRequest( tradeId );

            var response = new BaseSendRequest<Trade>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<List<Trade>> GetTrades( Guid? userId, OrderType? orderType, Side? side, string? symbol, OrderStatus? orderStatus )
        {
            var request = new GetTradesRequest( userId, orderType, side, symbol, orderStatus );

            var response = new BaseSendRequest<List<Trade>>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<Trade> UpdateTrade( Guid id, Guid userId, decimal price, decimal count, OrderType orderType, Side side, string symbol, OrderStatus orderStatus, TimeInForce timeInForce, DateTime createdDate )
        {
            var request = new UpdateTradeRequest( id, userId, price, count, orderType, side, symbol, orderStatus, timeInForce, createdDate );

            var response = new BaseSendRequest<Trade>().SendRequest( _client, request );

            return response;
        }
    }
}