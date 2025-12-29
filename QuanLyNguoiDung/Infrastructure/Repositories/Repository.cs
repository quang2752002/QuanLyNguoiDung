using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    
   public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

      

        public async Task<T?> GetByIdAsync(Guid id) => await _context.Set<T>().FindAsync(id);

        public async Task<List<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task Add(T entity) => await _context.Set<T>().AddAsync(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

      
    }
}