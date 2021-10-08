using Microsoft.AspNetCore.Identity;
using System;

namespace Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {

        }

        public string ContactDetails { get; set; }

        public string PhotoUrl { get; set; }
    }
}
