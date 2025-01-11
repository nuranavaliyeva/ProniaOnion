using ProniaOnion.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.Services
{
   public interface IProductService
    {
        Task<IEnumerable<ProductItemDto>> GetAllAsync(int page,int take); 
        Task<GetProductDto> GetByIdAsync(int id);
    }
}
