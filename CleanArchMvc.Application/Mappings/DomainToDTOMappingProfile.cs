﻿using AutoMapper;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;

namespace CleanArchMvc.Application.Mappings
{
        public class DomainToDTOMappingProfile : Profile
        {
            public DomainToDTOMappingProfile()
            {
                CreateMap<ProductCreateCommand, ProductDTO>().ReverseMap();
                CreateMap<ProductUpdateCommand, ProductDTO>().ReverseMap();
                CreateMap<ProductRemoveCommand, ProductDTO>().ReverseMap();
                CreateMap<ProductCommand, ProductDTO>().ReverseMap();
                CreateMap<Category, CategoryDTO>().ReverseMap();
                CreateMap<Product, ProductDTO>().ReverseMap();
            }
        }
}
