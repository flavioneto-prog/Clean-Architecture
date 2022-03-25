using CleanArchitecture.Application.Requests;
using CleanArchitecture.Application.Responses;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IUserService
    {
        UserResponse Add(AddUserRequest userInputModel);
        UserResponse Update(long id, UpdateUserRequest userInputModel);
        UserResponse GetById(long id);
        IEnumerable<UserResponse> GetAllUsers();
        void DeleteById(long id);
    }
}
