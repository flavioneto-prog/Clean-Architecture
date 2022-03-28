using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CleanArchitectureDbContext _dbContext;

        public UserRepository(CleanArchitectureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Usuario Add(DateTime dataNascimento, string email, string nome, string senha, char sexo)
        {
            var user = new Usuario
            {
                DataNascimento = dataNascimento,
                Email = email,
                Nome = nome,
                Senha = senha,
                Sexo = sexo
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user;
        }
        public IEnumerable<Usuario> GetAllUsers()
        {
            var users = _dbContext.Users.AsNoTracking().ToList();

            return users;
        }
        public Usuario GetById(long id)
        {
            var user = _dbContext.Users.AsNoTracking().Where(s => s.UsuarioId == id).FirstOrDefault();

            return user;
        }
        public Usuario Update(long id, string email, string nome, string senha)
        {
            var user = _dbContext.Users.Where(s => s.UsuarioId == id).FirstOrDefault();

            var dadosASeremAtualizados = new { Email = email, Nome = nome, Senha = senha };

            _dbContext.Entry(user).CurrentValues.SetValues(dadosASeremAtualizados);
            _dbContext.SaveChanges();

            return user;
        }
        public void DeleteById(long id)
        {
            var user = _dbContext.Users.AsNoTracking().Where(s => s.UsuarioId == id).FirstOrDefault();

            _dbContext.Users.Remove(user);
            _dbContext.SaveChangesAsync();
        }
    }
}
