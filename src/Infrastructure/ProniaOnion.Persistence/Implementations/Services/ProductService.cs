using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductItemDto>> GetAllAsync(int page, int take)
        {
            var products = _mapper.Map<IEnumerable<ProductItemDto>>(await _productRepository.GetAll(skip: (page - 1) * take, take: take).ToListAsync());
            return products;
        }

        public async Task<ProductGetDto> GetByIdAsync(int id)
        {
            var product = _mapper.Map<ProductGetDto>(await _productRepository.GetByIdAsync(id, "Category", "ProductColors.Color"));
            if (product == null) throw new Exception("Product does not exist");
            return product;
        }
    }
}
