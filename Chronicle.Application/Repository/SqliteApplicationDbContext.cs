using Chronicle.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chronicle.Application.Repository
{
    public class IdentityApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityApplicationDbContext(DbContextOptions<IdentityApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
