using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modsen.Data.Entities;

namespace Modsen.Data
{
    public class EventContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Event> Events { get; set; }

        public EventContext(DbContextOptions<EventContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
