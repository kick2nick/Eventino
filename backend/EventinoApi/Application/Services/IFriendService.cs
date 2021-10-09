using System;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IFriendService
    {
        IReadOnlyCollection<Guid> GetUserFriendsIds(Guid userId);
        bool AddFriend(Guid userId);
        bool DeleteFriend(Guid userId);
    }
}
