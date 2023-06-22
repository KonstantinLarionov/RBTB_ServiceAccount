using NUnit.Framework;
using RBTB_ServiceAccount.Client.Client;

namespace ServiceAccountTest
{
    public class TestPositions
    {
        private ServiceAccountClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new ServiceAccountClient( "http://localhost:5012/" );
        }

        [Test]
        public void GetPositions()
        {
            var positions = _client.Positions.GetPositions( null, null, null, null );
        }

        [Test]
        public void CreatePosition()
        {
            var createPosition = _client.Positions.CreatePosition( new Guid( "9accaf71-fe30-48dd-b8a0-062459b4cdf1" ), new Guid(), 30, "USDT", 20, RBTB_ServiceAccount.Client.Abstractions.Enums.Side.Buy, RBTB_ServiceAccount.Client.Abstractions.Enums.PositionStatus.Normal, DateTime.Now );
        }

        [Test]
        public void UpdatePosition()
        {
            var positionUpdate = _client.Positions.UpdatePosition( new Guid( "a6a6a2ca-380c-442c-a606-ddbc978bc64c" ), new Guid(), new Guid(), 100, "USDT", 20, RBTB_ServiceAccount.Client.Abstractions.Enums.Side.Buy, RBTB_ServiceAccount.Client.Abstractions.Enums.PositionStatus.Normal, DateTime.Now );
        }

        [Test]
        public void GetPositionById()
        {
            var position = _client.Positions.GetPositionById( new Guid( "a6a6a2ca-380c-442c-a606-ddbc978bc64c" ) );
        }

        [Test]
        public void DeletePosition()
        {
            var positionDelete = _client.Positions.DeletePosition( new Guid( "a6a6a2ca-380c-442c-a606-ddbc978bc64c" ) );
        }
    }
}