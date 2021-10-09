using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dal.DbContext
{
    public class EventinoDbContext : IdentityDbContext<User,IdentityRole<Guid>,Guid>
    {
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

            builder.Entity<Event>()
                .HasMany(e => e.Attendees)
                .WithMany(u => u.SubscribedEvents);
            builder.Entity<Event>()
                .HasOne(e => e.Host);

            builder.Entity<User>()
                .HasMany(u => u.Interests)
                .WithMany(i => i.Users);

            builder.Entity<User>()
                .HasMany(s => s.Friendships)
                .WithOne(s => s.User1);

            base.OnModelCreating(builder);
        }
    }
}
