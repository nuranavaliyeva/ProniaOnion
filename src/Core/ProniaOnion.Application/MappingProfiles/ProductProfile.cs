using AutoMapper;
using ProniaOnion.Application.DTOs.Color;
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
            CreateMap<Product, ProductGetDto>()
                .ForCtorParam(
               nameof(ProductGetDto.Colors),
                opt => opt.MapFrom(
                    p => p.ProductColors.Select(pc => new ColorItemDto(pc.ColorId, pc.Color.Name))
                    )
                );
        }
    }
}
