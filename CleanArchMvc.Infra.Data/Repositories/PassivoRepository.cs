using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class PassivoRepository : IPassivoRepository
    {
        private readonly ApplicationDbContext _context;

        public PassivoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Passivo> Create(Passivo passivo)
        {
            _context.Add(passivo);
            _context.SaveChangesAsync();
            return Task.FromResult(passivo);
        }

        public Task<IEnumerable<Passivo>> GetPassivos()
        {
            return Task.FromResult(_context.Passivos.AsEnumerable());
        }

        public Task<Passivo> GetById(int? id)
        {
            return Task.FromResult(_context.Passivos.Find(id));
        }

        public Task<Passivo> Remove(Passivo passivo)
        {
            _context.Remove(passivo);
            _context.SaveChangesAsync();
            return Task.FromResult(passivo);
        }

        public Task<IEnumerable<Passivo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Passivo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Passivo passivo)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Passivo passivo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PassivoExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Passivo>> GetByTipoAsync(string tipo)
        {
            throw new NotImplementedException();
        }
    }
    
}