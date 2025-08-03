using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IContaRepository
    {
        Task<IEnumerable<Conta>> GetAllAsync();
        Task<Conta> GetByIdAsync(int id);
        Task AddAsync(Conta conta);
        Task UpdateAsync(Conta conta);
        Task DeleteAsync(int id);
        Task<bool> ContaExistsAsync(int id);
        Task<IEnumerable<Conta>> GetByTipoAsync(string tipo);
    }
}