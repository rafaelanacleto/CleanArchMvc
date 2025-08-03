using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IPassivoRepository
    {
        Task<IEnumerable<Passivo>> GetAllAsync();
        Task<Passivo> GetByIdAsync(int id);
        Task AddAsync(Passivo passivo);
        Task UpdateAsync(Passivo passivo);
        Task DeleteAsync(int id);
        Task<bool> PassivoExistsAsync(int id);
        Task<IEnumerable<Passivo>> GetByTipoAsync(string tipo);
    }
}