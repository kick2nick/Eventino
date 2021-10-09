using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dal.DbContext
{
    public class EventinoDbContext : IdentityDbContext<User,IdentityRole<Guid>,Guid>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Event> Events { get; set; }

        public EventinoDbContext(DbContextOptions<EventinoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>()
                .HasMany(e => e.Interests)
                .WithMany(i => i.Events);

            base.OnModelCreating(builder);
        }
    }
}
