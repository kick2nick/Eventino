using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dal.DbContext
{
    public class EventinoDbContext : IdentityDbContext<User,IdentityRole<Guid>,Guid>
    {

        public EventinoDbContext(DbContextOptions<EventinoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
