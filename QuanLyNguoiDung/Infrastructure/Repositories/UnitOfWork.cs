using Domain.Entities;
using Domain.Interface;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRepository<User> Users { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new Repository<User>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
