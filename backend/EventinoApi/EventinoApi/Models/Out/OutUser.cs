using System;
using System.Collections.Generic;

namespace EventinoApi.Models.Out
{
    public class OutUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhotoFileName { get; set; }
        public IReadOnlyCollection<string> Interests { get; set; }
    }
}
