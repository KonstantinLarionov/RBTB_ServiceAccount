using NUnit.Framework;
using RBTB_ServiceAccount.Client.Client;

namespace ServiceAccountTest
{
    public class TestWallet
    {
        private ServiceAccountClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new ServiceAccountClient( "http://localhost:5012/" );
        }

        [Test]
        public void GetWallets()
        {
            var wallets = _client.Wallets.GetWallets( null, null );
        }

        [Test]
        public void CreateWallet()
        {
            var createWallet = _client.Wallets.CreateWallet( new Guid( "b7271016-bf2a-46f2-bd71-6c21c000a264" ), "USDT", 100);
        }

        [Test]
        public void UpdateWallet()
        {
            var walletUpdate = _client.Wallets.UpdateWallet( new Guid( "02d6c21a-2a87-48ca-9632-c1b4fcfa36ff" ), new Guid( "b7271016-bf2a-46f2-bd71-6c21c000a264" ), "USDT", 200 );
        }

        [Test]
        public void GetWalletById()
        {
            var wallet = _client.Wallets.GetWalletById( new Guid( "02d6c21a-2a87-48ca-9632-c1b4fcfa36ff" ) );
        }

        [Test]
        public void DeleteWallet()
        {
            var walletDelete = _client.Wallets.DeleteWallet( new Guid( "02d6c21a-2a87-48ca-9632-c1b4fcfa36ff" ) );
        }
    }
}