﻿using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Repositories
{
    internal class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public Repository(AppDbContext context)
        {
            _context = context;
            _table = context.Set<T>();

        }

        public IQueryable<T> GetAll(
            Expression<Func<T,
            bool>>? expression = null,
            int skip = 0,
            int take = 0,
            Expression<Func<T, object>>? orderExpression = null,
            bool isDescending = false,
            bool isTracking = false,
            params string[]? includes)
        {

            IQueryable<T> query = _table;

            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                query = _getIncludes(query, includes);
            }
            if (orderExpression != null)
            {
                if (isDescending)
                {
                    query = query.OrderByDescending(orderExpression);
                }
                else
                {
                    query = query.OrderBy(orderExpression);
                }
            }
            query = query.Skip(skip);
            if (take != 0)
            {
                query = query.Take(take);
            }

            return isTracking ? query : query.AsNoTracking();

        }

        public async Task<T> GetByIdAsync(int id, params string[] includes)
        {
            IQueryable<T> query = _table;
            if (includes != null)
            {
                query = _getIncludes(query, includes);
            }

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        private IQueryable<T> _getIncludes(IQueryable<T> query, params string[] includes)
        {

            for (int i = 0; i < includes.Length; i++)
            {
                query = query.Include(includes[i]);
            }
            return query;
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return _table.AnyAsync(expression);
        }
    }
}
