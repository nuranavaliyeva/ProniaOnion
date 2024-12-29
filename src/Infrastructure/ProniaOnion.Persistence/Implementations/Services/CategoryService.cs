using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task CreateAsync(CreateCategoryDto categoryDto)
        {
            if (await _categoryRepository.AnyAsync(c => c.Name == categoryDto.Name))
            {
                throw new Exception("Already Exists");
            }

            await _categoryRepository.AddAsync(new Category
            {
                Name = categoryDto.Name,
                CreatedAt=DateTime.Now,
                ModifiedAt=DateTime.Now 
            });
            await _categoryRepository.SaveChangesAsync();

           
        }

        public async Task DeleteAsync(int id)
        {

            Category category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) throw new Exception("Not Found");
            _categoryRepository.Delete(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<CategoryItemDto> categories = await _categoryRepository
            .GetAll(skip: (page - 1) * take, take: take)
            .Select(c => new CategoryItemDto(c.Id, c.Name))
            .ToListAsync();
            return categories;
     
        }

        public async Task<GetCategoryDto> GetByIdAsync(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id, nameof(Category.Products));
            if (category == null) return null;
            
            GetCategoryDto categoryDto = new(category.Id,category.Name,category.Products
                .Select(p => new ProductItemDto(p.Id,p.Price,p.Name,p.SKU,p.Description)).ToList());
            
          
            return categoryDto;
        }

        public async Task UpdateAsync(int id, UpdateCategoryDto categoryDto)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) throw new Exception("Not Found");
            if (await _categoryRepository.AnyAsync(c => c.Name == categoryDto.Name && c.Id != id)) throw new Exception("Already exists");
            category.Name = categoryDto.Name;
            category.ModifiedAt= DateTime.Now;
            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();
        }
    }
}
