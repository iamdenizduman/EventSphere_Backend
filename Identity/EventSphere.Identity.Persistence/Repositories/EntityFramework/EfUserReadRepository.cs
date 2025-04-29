using EventSphere.Core.Repository.Abstract.EntityFramework;
using EventSphere.Identity.Domain.Entities;
using EventSphere.Identity.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventSphere.Identity.Persistence.Repositories.EntityFramework
{
    public class EfUserReadRepository : EfEntityReadRepository<User>, IUserReadRepository
    {
        private readonly DbContext _context;
        public EfUserReadRepository(DbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<User?> GetUserWithClaimsAsync(string email)
        {
            return await _context.Set<User>().Include(u => u.UserOperationClaims)
                .ThenInclude(uoc => uoc.OperationClaim)
                .SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
