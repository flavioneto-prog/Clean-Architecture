using System;

namespace CleanArchitecture.Application.Responses
{
    public class UserResponse
    {
        public UserResponse(long usuarioId, DateTime? dataNascimento, string email, string nome, char sexo)
        {
            UsuarioId = usuarioId;
            DataNascimento = dataNascimento;
            Email = email;
            Nome = nome;
            Sexo = sexo;
        }

        public long UsuarioId { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public char Sexo { get; private set; }
    }
}
