using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Application.DTOs.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.DTOs.Products
{
    public record ProductGetDto(int Id,string Name,decimal Price ,string SKU ,
                                string Description,CategoryItemDto Category ,
                                IEnumerable<ColorItemDto> Colors) { }
    
}
