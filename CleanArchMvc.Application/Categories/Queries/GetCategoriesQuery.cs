using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<Category>>
    {
        
    }
}