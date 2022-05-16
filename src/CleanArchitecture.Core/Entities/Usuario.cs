using System;
using CleanArchitecture.Core.Extensions;

namespace CleanArchitecture.Core.Entities
{
    public class Usuario
    {
        public Usuario(DateTime? dataNascimento, string email, string nome, string senha, char sexo)
        {
            SetDataNascimento(dataNascimento);
            SetEmail(email);
            SetNome(nome);
            SetSenha(senha);
            SetSexo(sexo);
        }

        public long UsuarioId { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public char Sexo { get; private set; }

        private void SetDataNascimento(DateTime? dataNascimento)
        {
            int anoParaMaiorIdade = DateTime.Now.Year - 18;

            if (dataNascimento.Value.Year < anoParaMaiorIdade)
                DataNascimento = dataNascimento;
            else
                throw new Exception("Não é permitido o cadastro para " +
                    "usuários que não possuirem a maior idade.");
        }
        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Não é permitido o cadastro para" +
                    "usuários que não possuirem email.");

            Email = email;
        }
        private void SetNome(string nome)
        {
            int quantidadeMinimaPermitidaNome = 4;

            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("não é possível cadastrar" +
                    "um usuário sem nome.");

            if (nome.Length < quantidadeMinimaPermitidaNome)
                throw new Exception("não é possível cadastrar" +
                    "um usuário com nome abreviado ou com apenas primeiro nome");

            Nome = nome;
        }
        private void SetSenha(string senha)
        {
            Senha = EncryptionExtensions.EncryptString("b14ca5898a4e4133bbce2ea2315a1916", senha);
        }
        private void SetSexo(char sexo)
        {
            Sexo = Convert.ToChar(sexo.ToString().ToUpper());
        }
    }
}
