using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Repositories
{
    internal class ProductRepository:Repository<Product>,IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<T>> GetManyToManyEntities<T>(ICollection<int> ids) where T : BaseEntity
        {
          return await _context.Set<T>().Where(c=>ids.Contains(c.Id)).ToListAsync();
            
        }
    }
}
