﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modsen.DL.Entities;

namespace Modsen.DL
{
    public class EventContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Event> Events { get; set; }

        public EventContext(DbContextOptions<EventContext> options)
        : base(options)
        {
            
        }
    }
}
