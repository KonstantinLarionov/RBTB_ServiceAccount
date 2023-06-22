using RBTB_ServiceAccount.Abstractions.Models;
using RBTB_ServiceAccount.Client.Abstractions.Enums;
using RBTB_ServiceAccount.Client.Common;
using RBTB_ServiceAccount.Client.Requests.Positions;
using RestSharp;

namespace RBTB_ServiceAccount.Client.Client
{
    public class PositionsClient
    {
        private readonly IRestClient _client;

        public PositionsClient( IRestClient client ) 
        {
            _client = client;
        }

        public BaseResponse<Guid> CreatePosition( Guid userId,
            Guid tradesId,
            decimal price,
            string symbol,
            decimal count,
            Side side,
            PositionStatus positionStatus,
            DateTime createdDate )
        {
            var request = new CreatePositionRequest( userId,
                tradesId,
                price,
                symbol,
                count,
                side,
                positionStatus,
                createdDate );

            var response = new BaseSendRequest<Guid>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<Guid> DeletePosition( Guid positionId )
        {
            var request = new DeletePositionRequest( positionId );

            var response = new BaseSendRequest<Guid>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<Position> GetPositionById( Guid positionId )
        {
            var request = new GetPositionByIdRequest( positionId );

            var response = new BaseSendRequest<Position>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<List<Position>> GetPositions( Guid? userId, Side? side, PositionStatus? positionStatus, string? symbol )
        {
            var request = new GetPositionsRequest( userId, side, positionStatus, symbol );

            var response = new BaseSendRequest<List<Position>>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<Position> UpdatePosition( Guid id,
            Guid userId,
            Guid tradesId,
            decimal price,
            string symbol,
            decimal count,
            Side side,
            PositionStatus positionStatus,
            DateTime createdDate )
        {
            var request = new UpdatePositionRequest( id, userId, tradesId, price, symbol, count, side, positionStatus, createdDate );

            var response = new BaseSendRequest<Position>().SendRequest( _client, request );

            return response;
        }
    }
}