using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
        Task<bool> UsuarioExistsAsync(int id);
        Task<IEnumerable<Usuario>> GetByRoleAsync(string role);
        Task<IEnumerable<Usuario>> GetByEmailAsync(string email);
        Task<Usuario> AuthenticateAsync(string email, string password);
        Task<IEnumerable<Usuario>> GetByStatusAsync(bool isActive);
    }
}