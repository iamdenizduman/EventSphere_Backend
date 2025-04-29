using EventSphere.Core.Repository.Abstract.EntityFramework;
using EventSphere.Identity.Domain.Entities;
using EventSphere.Identity.Domain.Repositories;
using EventSphere.Identity.Persistence.Repositories.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;


namespace EventSphere.Identity.Persistence.Repositories.EntityFramework
{
    public class EfUserWriteRepository(IdentityDbContext context) : EfEntityWriteRepository<User>(context), IUserWriteRepository
    {
    }
}
