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
        Task<Conta> GetByIdAsync(Guid id);
        Task AddAsync(Conta conta);
        Task UpdateAsync(Conta conta);
        Task DeleteAsync(Guid id);
        Task<bool> ContaExistsAsync(Guid id);
    }
}