using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Requests
{
    public class UpdateUserRequest
    {
        [Required(ErrorMessage = "O e-mail é requerido.")]
        [EmailAddress(ErrorMessage = "E-mail informado no formato inválido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O nome é requerido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A senha é requerida")]
        public string Senha { get; set; }
    }
}
