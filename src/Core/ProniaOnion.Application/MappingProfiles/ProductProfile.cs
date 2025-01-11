using AutoMapper;
using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Application.DTOs.Colors;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductItemDto>().ReverseMap();

            //CreateMap<Product, GetProductDto>()
            //   .ConvertUsing(p=>new GetProductDto(
            //       p.Id,
            //   p.Price,
            //   p.Name,
            //   p.SKU,
            //   p.Description,
            //   new CategoryItemDto(p.CategoryId,p.Category.Name),
            //   p.ProductColors.Select(pc=>new ColorItemDto(pc.ColorId,pc.Color.Name))

            //   ));

            CreateMap<Product, GetProductDto>()
               .ForCtorParam(nameof(GetProductDto.Colors),opt=>opt.MapFrom (p => p.ProductColors.Select(pc => new ColorItemDto(pc.ColorId, pc.Color.Name))));
        }
    }
}
