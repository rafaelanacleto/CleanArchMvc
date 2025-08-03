using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IAtivoRepository
    {
        Task<IEnumerable<Ativo>> GetAtivos();
        Task<Ativo> GetById(int? id);
        Task<Ativo> Create(Ativo ativo);
        Task<Ativo> Update(Ativo ativo);
        Task<Ativo> Remove(Ativo ativo);
        Task<IEnumerable<Ativo>> GetAtivosByCategoryId(int categoryId);
        Task<IEnumerable<Ativo>> GetAtivosByStatus(bool status);
        Task<IEnumerable<Ativo>> GetAtivosByDateRange(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Ativo>> GetAtivosByPriceRange(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<Ativo>> GetAtivosByName(string name);
    }
}