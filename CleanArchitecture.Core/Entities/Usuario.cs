using System;

namespace CleanArchitecture.Core.Entities
{
    public class Usuario
    {
        public long UsuarioId { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public char Sexo { get; set; }
    }
}
