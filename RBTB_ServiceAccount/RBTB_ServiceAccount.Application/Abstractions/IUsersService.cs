using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Requests;
using RBTB_ServiceAccount.Application.Domains.Responses;

namespace RBTB_ServiceAccount.Application.Abstractions
{
    public interface IUsersService
    {
        BaseResponse<Users> GetUser(Guid id);

        BaseResponse<Guid> AddUser(AddUserRequest request);

        BaseResponse<bool> DeleteUser(Guid id);

        BaseResponse<bool> UpdateUser(Users user);

        BaseResponse<List<Users>> GetUserById(Guid id);
    }
}