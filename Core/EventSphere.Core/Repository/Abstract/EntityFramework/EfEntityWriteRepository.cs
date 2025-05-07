using EventSphere.Core.Entity.Interfaces;
using EventSphere.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.Core.Repository.Abstract.EntityFramework
{
    public abstract class EfEntityWriteRepository<T>(DbContext context) : IEntityWriteRepository<T>, IEntityBaseRepository<T>
        where T : class, IEntity
    {
        private readonly DbContext _context = context;

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
