using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Financeiro()
        {
        }
    }
}
