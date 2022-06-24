using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Application.Products.Commands;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {            
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if(productsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var productsQueryById = new GetProductByIdQuery(id);

            if(productsQueryById == null)
                throw new Exception($"Erroer");

            var result = await _mediator.Send(productsQueryById);    
            
            return _mapper.Map<ProductDTO>(productsQueryById);
        }

        public async Task<ProductDTO> GetProductCategory(int id)
        {
            var productEntity = await _mediator.Send(GetProductCategory(id));
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task Add(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int id)
        {
            var productRemoveCommand = _mapper.Map<ProductRemoveCommand>(id);
            await _mediator.Send(productRemoveCommand);
        }

    }
}
