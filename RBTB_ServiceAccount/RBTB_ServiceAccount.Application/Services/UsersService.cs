using RBTB_ServiceAccount.Application.Abstractions;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Requests;
using RBTB_ServiceAccount.Application.Domains.Responses;
using RBTB_ServiceAccount.Database.Abstractions;

namespace RBTB_ServiceAccount.Application.Services;
public class UsersService : IUsersService
{
    private IRepository<Users> _repositoryUsers;

    public UsersService(IRepository<Users> Users)
    {
        _repositoryUsers = Users;
    }

    public BaseResponse<Users> GetUser(Guid id)
    {
        var user = _repositoryUsers.FindById(id);
        if (user == null)
        {
            return new BaseResponse<Users>
            {
                IsSuccess = false,
                ErrorMessage = $"User with id {id} not found"
            };
        }
        return new BaseResponse<Users>
        {
            Data = user
        };
    }

    public BaseResponse<Guid> AddUser(AddUserRequest request)
    {
        var user = new Users
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            Login = request.Login,
            Password = request.Password,
            CreatedDate = request.CreatedDate,
            RefferalFrom = Guid.NewGuid(),
            RefferalCode = request.RefferalCode
        };

        var userUpdateResult = _repositoryUsers.Create(user);

        if (userUpdateResult == 0)
        {
            return new BaseResponse<Guid>
            {
                IsSuccess = false,
                ErrorMessage = $"Don`t added user{user}"
            };
        }

        return new BaseResponse<Guid>
        {
            Data = user.Id
        };
    }


    public BaseResponse<bool> DeleteUser (Guid id)
    {
        var userDeleteResult = _repositoryUsers.FindById(id);

        if (userDeleteResult != null)
        {
            var removeUserResult = _repositoryUsers.Remove(userDeleteResult);
            if (removeUserResult != 0)
            {
                return new BaseResponse<bool>();
            }
        }

        return new BaseResponse<bool>
        {
            IsSuccess = false,
            ErrorMessage = $"User don`t delete. User:{id}"
        };
    }

    public BaseResponse<bool> UpdateUser(Users user)
    {
        var userUpdateResult = _repositoryUsers.Update(user);

        if (userUpdateResult == 0)
        {
            return new BaseResponse<bool>
            {
                IsSuccess = false,
                ErrorMessage = $"User don`t update. User:{user}"
            };
        }

        return new BaseResponse<bool>
        {
            IsSuccess = true
        };
    }

    public BaseResponse<List<Users>> GetUserById(Guid id)
    {
        var user = _repositoryUsers.Get().Where(t => t.Id == id).ToList();

        return new BaseResponse<List<Users>>
        {
            Data = user
        };
    }
}