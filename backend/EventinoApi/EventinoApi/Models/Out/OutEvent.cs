using Domain.Enums;
using System;
using System.Collections.Generic;

namespace EventinoApi.Models.Out
{
    public record OutEvent
    {
        public Guid Id { get; init; }
        public Guid HostId { get; init; }

        public string Title { get; init; }
        public string Description { get; init; }
        public string PhotoUrl { get; init; }
        public string Place { get; init; }
        public EventType Type { get; init; }
        public EventStatus Status { get; init; }

        public int MaxMembers { get; init; }

        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public IReadOnlyCollection<Guid> Attendees { get; init; }
        public IReadOnlyCollection<Guid> FriendsSubscr { get; init; }
        public IReadOnlyCollection<string> Interests { get; init; }
        public int ViewsCount { get; init; }
    }
}
