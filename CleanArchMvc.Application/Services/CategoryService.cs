using AutoMapper;
using CleanArchMvc.Application.Categories.Commands;
using CleanArchMvc.Application.Categories.Queries;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {        
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CategoryService(IMapper mapper, IMediator mediator)
        {      
            _mapper = mapper;
            _mediator = mediator;
        }   
       
        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = new GetCategoriesQuery();
            if (categoriesEntity == null)
                throw new System.Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(categoriesEntity);

            return _mapper.Map<IEnumerable<CategoryDTO>>(result);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var categoryEntity = new GetCategoryByIdQuery(id);

            if (categoryEntity == null)
                throw new System.Exception($"Entity could not be loaded.");
            var result = await _mediator.Send(categoryEntity);

            return _mapper.Map<CategoryDTO>(result);
        }

        public async Task Add(CategoryDTO categoryDto)
        {
            var categoryEntity = new CategoryCreateCommand();

            if (categoryDto == null)
                throw new System.Exception($"Entity could not be loaded.");

            categoryEntity = _mapper.Map<CategoryCreateCommand>(categoryDto);            
        }

        public async Task Update(CategoryDTO categoryDto)
        {
            var categoryEntity = new CategoryUpdateCommand(categoryDto);

            if (categoryDto == null)
                throw new System.Exception($"Entity could not be loaded.");

            categoryEntity = _mapper.Map<CategoryUpdateCommand>(categoryDto);
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = new CategoryRemoveCommand(id);

            if (categoryEntity == null)
                throw new System.Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(categoryEntity);
        }
    }
}
