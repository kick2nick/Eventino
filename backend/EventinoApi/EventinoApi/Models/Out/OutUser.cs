using Domain.Entities;
using System;
using System.Collections.Generic;

namespace EventinoApi.Models.Out
{
    public class OutUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Interest> Interests { get; set; }
        public List<Guid> SubscribedEventIds { get; set; }
        public List<Guid> HostedEventIds { get; set; }
    }
}
