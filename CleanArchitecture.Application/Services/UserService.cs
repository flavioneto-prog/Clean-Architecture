using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Requests;
using CleanArchitecture.Application.Responses;
using CleanArchitecture.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserResponse Add(AddUserRequest userInputModel)
        {
            var user = _userRepository.Add(userInputModel.DataNascimento, userInputModel.Email, userInputModel.Nome, userInputModel.Senha, userInputModel.Sexo);
            return new UserResponse(user.UsuarioId, user.DataNascimento, user.Email, user.Nome, user.Sexo);
        }
        public IEnumerable<UserResponse> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();

            var listUsers = new List<UserResponse>();

            if (users.Any())
            {
                foreach (var item in users)
                {
                    listUsers.Add(new UserResponse(item.UsuarioId, item.DataNascimento, item.Email, item.Nome, item.Sexo));
                }
                return listUsers;
            }
            else
                return null;
        }
        public UserResponse GetById(long id)
        {
            var user = _userRepository.GetById(id);

            if (user is not null)
                return new UserResponse(user.UsuarioId, user.DataNascimento, user.Email, user.Nome, user.Sexo);
            else
                return null;
        }
        public UserResponse Update(long id, UpdateUserRequest userInputModel)
        {
            var user = GetById(id);

            if (user is not null)
            {
                var userUpdate = _userRepository.Update(id, userInputModel.Email, userInputModel.Nome, userInputModel.Senha);
                return new UserResponse(userUpdate.UsuarioId, userUpdate.DataNascimento, userUpdate.Email, userUpdate.Nome, userUpdate.Sexo);
            }
            else
                throw new Exception("Usuário não encontrado com o dado informado.");
        }
        public void DeleteById(long id)
        {
            var user = _userRepository.GetById(id);

            if (user is not null)
            {
                _userRepository.DeleteById(id);
            }
            else
                throw new Exception("Usuário não encontrado com o dado informado.");
        }
    }
}
