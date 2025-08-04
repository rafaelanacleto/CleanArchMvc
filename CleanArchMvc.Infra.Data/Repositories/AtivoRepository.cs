using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class AtivoRepository : IAtivoRepository
    {

        private readonly ApplicationDbContext _context;

        public AtivoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Ativo> Create(Ativo ativo)
        {
            _context.Add(ativo);
            _context.SaveChangesAsync();
            return Task.FromResult(ativo);
        }

        public Task<IEnumerable<Ativo>> GetAtivos()
        {
            return Task.FromResult(_context.Ativos.AsEnumerable());
        }


        public Task<IEnumerable<Ativo>> GetAtivosByDateRange(DateTime startDate, DateTime endDate)
        {
            return Task.FromResult(_context.Ativos.Where(a => a.DataCriacao >= startDate && a.DataCriacao <= endDate).AsEnumerable());
        }

        public Task<IEnumerable<Ativo>> GetAtivosByName(string name)
        {
            return Task.FromResult(_context.Ativos.Where(a => a.Nome.Contains(name)).AsEnumerable());
        }

        public Task<IEnumerable<Ativo>> GetAtivosByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return Task.FromResult(_context.Ativos.Where(a => a.Valor >= minPrice && a.Valor <= maxPrice).AsEnumerable());
        }

        public Task<IEnumerable<Ativo>> GetAtivosByStatus(bool status)
        {
            return Task.FromResult(_context.Ativos.Where(a => a.IsAtivo == status).AsEnumerable());
        }

        public Task<Ativo> GetById(int? id)
        {
            return Task.FromResult(_context.Ativos.Find(id));
        }

        public Task<Ativo> Remove(Ativo ativo)
        {
            _context.Remove(ativo);
            _context.SaveChangesAsync();
            return Task.FromResult(ativo);
        }

        public Task<Ativo> Update(Ativo ativo)
        {
            _context.Update(ativo);
            _context.SaveChangesAsync();
            return Task.FromResult(ativo);
        }
    }
}