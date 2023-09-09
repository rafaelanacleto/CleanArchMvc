using CleanArchMvc.Domain.Validation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Financeiro : Entity
    {
        // Campos
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public bool FoiPago { get; set; }
        public int AlunoId { get; set; }


        // Construtor
        public Financeiro(string nome, string tipo, decimal valor, DateTime dataTransacao, string descricao,
                           string categoria, bool foiPago, int alunoId)
        {
            ValidateDomain(nome, tipo, valor, dataTransacao, descricao, categoria, foiPago, alunoId);
        }

        private void ValidateDomain(string nome, string tipo, decimal valor, DateTime dataTransacao, string descricao,
                            string categoria, bool foiPago, int alunoId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(nome.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(tipo),
                "Invalid Tipo. Tipo is required");

            DomainExceptionValidation.When(valor < 0,
                "Invalid Valor, too short, minimum 5 characters");

            DomainExceptionValidation.When(valor < 0, "Invalid valor value");

            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Invalid Descricao, Descricao is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(categoria), "Invalid Categoria, Categoria is required");
            
            Nome = nome;
            Tipo = tipo;
            Valor = valor;
            DataTransacao = dataTransacao;
            Descricao = descricao;
            Categoria = categoria;
            FoiPago = foiPago;
            AlunoId = alunoId;

        }

    }
}
