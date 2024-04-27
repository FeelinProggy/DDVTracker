using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace DDVTracker.Data
{
    public class DreamlightDbContext : IdentityDbContext
    {
        public DreamlightDbContext(DbContextOptions<DreamlightDbContext> options) : base(options)
        {
        }

    }
}
