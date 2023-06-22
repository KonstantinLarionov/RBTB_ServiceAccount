using NUnit.Framework;
using RBTB_ServiceAccount.Client.Client;

namespace ServiceAccountTest
{
    public class TestTrade
    {
        private ServiceAccountClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new ServiceAccountClient( "http://localhost:5012/" );
        }

        [Test]
        public void GetTrades()
        {
            var trades = _client.Trades.GetTrades( null, null, null, null, null );
        }

        [Test]
        public void CreateTrade()
        {
            var createTrade = _client.Trades.CreateTrade( new Guid( "b7271016-bf2a-46f2-bd71-6c21c000a264" ), 
                10, 10, RBTB_ServiceAccount.Client.Abstractions.Enums.OrderType.Limit, RBTB_ServiceAccount.Client.Abstractions.Enums.Side.Buy, 
                "USDT", RBTB_ServiceAccount.Client.Abstractions.Enums.OrderStatus.Created, RBTB_ServiceAccount.Client.Abstractions.Enums.TimeInForce.GoodTillCancel, DateTime.Now );
        }

        [Test]
        public void UpdateTrade()
        {
            var tradeUpdate = _client.Trades.UpdateTrade( new Guid( "9accaf71-fe30-48dd-b8a0-062459b4cdf1" ), new Guid( "9accaf71-fe30-48dd-b8a0-062459b4cdf1" ),
                10, 10, RBTB_ServiceAccount.Client.Abstractions.Enums.OrderType.Limit, RBTB_ServiceAccount.Client.Abstractions.Enums.Side.Buy,
                "USDT", RBTB_ServiceAccount.Client.Abstractions.Enums.OrderStatus.Created, RBTB_ServiceAccount.Client.Abstractions.Enums.TimeInForce.GoodTillCancel, DateTime.Now );
        }

        [Test]
        public void GetTradeById()
        {
            var trade = _client.Trades.GetTradeById( new Guid( "b7271016-bf2a-46f2-bd71-6c21c000a264" ) );
        }

        [Test]
        public void DeleteTrade()
        {
            var tradeDelete = _client.Trades.DeleteTrade( new Guid( "b7271016-bf2a-46f2-bd71-6c21c000a264" ) );
        }
    }
}