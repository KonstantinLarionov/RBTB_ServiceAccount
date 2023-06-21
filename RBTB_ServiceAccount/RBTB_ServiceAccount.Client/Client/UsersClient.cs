using RBTB_ServiceAccount.Abstractions.Models;
using RBTB_ServiceAccount.Client.Common;
using RBTB_ServiceAccount.Client.Requests.Users;
using RestSharp;

namespace RBTB_ServiceAccount.Client.Client
{
    public class UsersClient
    {
        private readonly IRestClient _client;

        public UsersClient( IRestClient client ) 
        {
            _client = client;
        }

        public BaseResponse<Guid> CreateUser( string username, string login, string password, DateTime createdDate, Guid refferalFrom )
        {
            var request = new CreateUserRequest( username, login, password, createdDate, refferalFrom );

            var response = new BaseSendRequest<Guid>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<Guid> DeleteUser( Guid userId )
        {
            var request = new DeleteUserRequest( userId );

            var response = new BaseSendRequest<Guid>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<User> GetUserById( Guid userId )
        {
            var request = new GetUserByIdRequest( userId );

            var response = new BaseSendRequest<User>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<List<User>> GetUsers()
        {
            var request = new GetUsersRequest();

            var response = new BaseSendRequest<List<User>>().SendRequest( _client, request );

            return response;
        }

        public BaseResponse<User> UpdateUser( Guid id, string username, string login, string password, DateTime createdDate, Guid refferalFrom )
        {
            var request = new UpdateUserRequest( id, username, login, password, createdDate, refferalFrom );

            var response = new BaseSendRequest<User>().SendRequest( _client, request );

            return response;
        }
    }
}