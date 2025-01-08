using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.DTOs.Products
{
    public record CreateProductDto(
        decimal Price,
        string Name,
        string SKU,
        string Description,
        int CategoryID,
        ICollection<int> ColorIds
        )
    {
    }
}
