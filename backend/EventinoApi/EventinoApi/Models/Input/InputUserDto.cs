using System;
using System.ComponentModel.DataAnnotations;

namespace EventinoApi.Models.Input
{
    public class InputUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null;
        [EmailAddress]
        public string Email { get; set; } = null;
        public string PhotoFileName { get; set; } = null;
        public int[] InterestIds { get; set; } = null;

    }
}
