using NUnit.Framework;
using RBTB_ServiceAccount.Client.Client;

namespace ServiceAccountTest
{
    public class TestUser
    {
        private ServiceAccountClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new ServiceAccountClient( "http://localhost:5012/" );
        }

        [Test]
        public void GetUsers()
        {
            var users = _client.Users.GetUsers();
        }

        [Test]
        public void CreateUser()
        {
            var createUser = _client.Users.CreateUser( "test", "test", "test", DateTime.Now, new Guid( "02d6c21a-2a87-48ca-9632-c1b4fcfa36ff" ) );
        }

        [Test]
        public void UpdateUser()
        {
            var userUpdate = _client.Users.UpdateUser( new Guid( "aa3aaa21-b1ad-4494-80d6-f544ae980203" ), "test____", "test", "test", DateTime.Now, new Guid( "02d6c21a-2a87-48ca-9632-c1b4fcfa36ff" ) );
        }

        [Test]
        public void GetUserById()
        {
            var user = _client.Users.GetUserById( new Guid( "aa3aaa21-b1ad-4494-80d6-f544ae980203" ) );
        }

        [Test]
        public void DeleteUser()
        {
            var userDelete = _client.Users.DeleteUser( new Guid( "aa3aaa21-b1ad-4494-80d6-f544ae980203" ) );
        }
    }
}