using ProniaOnion.Application.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryItemDto>> GetAllAsync(int page, int take);
        Task<GetCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCategoryDto categoryDto);
        Task UpdateAsync(int id, UpdateCategoryDto categoryDto);
        Task DeleteAsync(int id);
    }
}
