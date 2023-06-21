using NUnit.Framework;
using RBTB_ServiceAccount.Client.Client;
using RestSharp;

namespace ServiceAccountTest
{
    public class TestPositions
    {
        private ServiceAccountClient _client;

        [SetUp]
        public void Setup()
        {
            IRestClient client = new RestClient( "http://localhost:5012/" );
            _client = new ServiceAccountClient( client );
        }

        [Test]
        public void Test1()
        {
            var test = _client.Positions.GetPositions( null, null, null, "test" );
        }
    }
}