using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Agenda : Entity
    {
        // Campos
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public List<Aluno> Participantes { get; set; }
        public bool Concluido { get; set; }
        public string Local { get; set; }

        // Construtor
        public Agenda()
        {
            Participantes = new List<Aluno>();
        }
    }
}
