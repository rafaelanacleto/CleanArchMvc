using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Aluno : Entity
    {
        // Campos
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Matricula { get; set; }
        public string Curso { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco EnderecoResidencial { get; set; }

        // Construtor
        public Aluno()
        {
            EnderecoResidencial = new Endereco();
        }
    }
}
