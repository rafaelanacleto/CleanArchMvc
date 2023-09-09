using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IFinanceiroRepository
    {
        List<Financeiro> GetAll();
        Financeiro GetById(int id);
        void Create(Financeiro financeiro);
        void Update(int id, Financeiro financeiro);
        void Delete(int id);
    }
}
