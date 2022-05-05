using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;

public class CategoryRepository : ICategoryRepository
{
    ApplicationDbContext _categoryContext;

    public CategoryRepository(ApplicationDbContext context)
    {
        _categoryContext = context;
    }

    public Task<Category> Create(Category category)
    {
        throw new System.NotImplementedException();
    }

    public Task<Category> GetById(int? id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetCatories()
    {
        throw new System.NotImplementedException();
    }

    public Task<Category> Remove(Category category)
    {
        throw new System.NotImplementedException();
    }

    public Task<Category> Update(Category category)
    {
        throw new System.NotImplementedException();
    }
}