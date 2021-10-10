using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventinoApi.Models.Input
{
    public record InputUserDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        [EmailAddress]
        public string Email { get; init; }
        public string PhotoFileName { get; init; }
        public IReadOnlyCollection<string> Interests { get; init; }
    }
}
