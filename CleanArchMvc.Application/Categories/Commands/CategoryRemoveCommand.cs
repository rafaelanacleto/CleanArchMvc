using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Categories.Commands
{
    public class CategoryRemoveCommand : IRequest<Category>
    {
        public int Id { get; set; }
        
        public CategoryRemoveCommand(int id)
        {
            Id = id;
        }

    }
}