using EventSphere.Core.Repository.Abstract.EntityFramework;
using EventSphere.Identity.Domain.Entities;
using EventSphere.Identity.Domain.Repositories;
using EventSphere.Identity.Persistence.Repositories.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace EventSphere.Identity.Persistence.Repositories.EntityFramework
{
    public class EfUserReadRepository : EfEntityReadRepository<User>, IUserReadRepository
    {
        private readonly IdentityDbContext _context;
        public EfUserReadRepository(IdentityDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<User?> GetUserWithClaimsAsync(string email)
        {
            return await _context.Users.Include(u => u.UserOperationClaims)
                .ThenInclude(uoc => uoc.OperationClaim)
                .SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
