using CleanArchMvc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Categories.Commands
{
    public class CategoryUpdateCommand : CategoryCommand
    {
        public CategoryUpdateCommand(CategoryDTO categoryDTO)
        {
            
        }
        
        // Additional properties or methods can be added here if needed
        // This class inherits from CategoryCommand and can be used to update a category
        // with the specified Id and Name.
    }
}