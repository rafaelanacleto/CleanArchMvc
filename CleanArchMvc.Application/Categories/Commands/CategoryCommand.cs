using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Categories.Commands
{
    public abstract class CategoryCommand : IRequest<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}