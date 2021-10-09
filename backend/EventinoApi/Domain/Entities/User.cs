using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {

        }

        public string ContactDetails { get; set; }

        public string PhotoUrl { get; set; }

        public ICollection<User> Friends { get; set; }
    }
}
