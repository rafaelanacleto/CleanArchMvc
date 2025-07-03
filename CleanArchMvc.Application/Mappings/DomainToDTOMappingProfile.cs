using AutoMapper;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Categories.Commands;

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

                CreateMap<CategoryCreateCommand, CategoryDTO>().ReverseMap();
                CreateMap<CategoryUpdateCommand, CategoryDTO>().ReverseMap();
                CreateMap<CategoryRemoveCommand, CategoryDTO>().ReverseMap();
                CreateMap<CategoryCommand, CategoryDTO>().ReverseMap();

                CreateMap<Category, CategoryDTO>().ReverseMap();
                CreateMap<Product, ProductDTO>().ReverseMap();
            }
        }
}
