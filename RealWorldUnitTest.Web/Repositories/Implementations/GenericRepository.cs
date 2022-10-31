using Microsoft.EntityFrameworkCore;
using RealWorldUnitTest.Web.Models;
using RealWorldUnitTest.Web.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealWorldUnitTest.Web.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly UnitTestDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(UnitTestDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            // _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}
