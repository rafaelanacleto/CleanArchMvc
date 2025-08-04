using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly ApplicationDbContext _context;

        public ContaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Conta> GetById(Guid id)
        {
            return Task.FromResult(_context.Contas.Find(id));
        }

        public Task<Conta> Remove(Conta conta)
        {
            _context.Remove(conta);
            _context.SaveChangesAsync();
            return Task.FromResult(conta);
        }

        public Task<IEnumerable<Conta>> GetAllAsync()
        {
            _context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
            return Task.FromResult(_context.Contas.AsEnumerable());
        }

        public Task<Conta> GetByIdAsync(Guid id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
            return Task.FromResult(_context.Contas.Find(id));
        }

        public Task AddAsync(Conta conta)
        {
            _context.Add(conta);
            _context.SaveChangesAsync();
            return Task.FromResult(conta);
        }

        public Task UpdateAsync(Conta conta)
        {
            _context.Update(conta);
            _context.SaveChangesAsync();
            return Task.FromResult(conta);
        }

        public Task DeleteAsync(Guid id)
        {
            var conta = _context.Contas.Find(id);
            if (conta != null)
            {
                _context.Remove(conta);
                _context.SaveChangesAsync();
            }
            return Task.FromResult(conta);
        }

        public Task<bool> ContaExistsAsync(Guid id)
        {
            return Task.FromResult(_context.Contas.Any(c => c.Id == id));
        }

    }
}