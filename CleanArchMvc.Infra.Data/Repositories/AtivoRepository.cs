using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Infra.Data.Repositories;

public class AtivoRepository : IAtivoRepository
{
    public Task<IEnumerable<Ativo>> GetAtivos()
    {
        throw new NotImplementedException();
    }

    public Task<Ativo> GetById(int? id)
    {
        throw new NotImplementedException();
    }

    public Task<Ativo> Create(Ativo ativo)
    {
        throw new NotImplementedException();
    }

    public Task<Ativo> Update(Ativo ativo)
    {
        throw new NotImplementedException();
    }

    public Task<Ativo> Remove(Ativo ativo)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Ativo>> GetAtivosByCategoryId(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Ativo>> GetAtivosByStatus(bool status)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Ativo>> GetAtivosByDateRange(DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Ativo>> GetAtivosByPriceRange(decimal minPrice, decimal maxPrice)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Ativo>> GetAtivosByName(string name)
    {
        throw new NotImplementedException();
    }
}