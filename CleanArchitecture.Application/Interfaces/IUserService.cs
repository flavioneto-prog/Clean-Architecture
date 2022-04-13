using System.Collections.Generic;
using CleanArchitecture.Application.Requests;
using CleanArchitecture.Application.Responses;

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