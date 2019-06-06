using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Logic
{
    public class Users
    {
        public string UserId { get; }
        public string User { get; }
        public int? MessagesCount { get; set; }

        public Users(string userId, string username, int? messagesCount)
        {
            UserId = userId;
            User = username;
            MessagesCount = messagesCount;
        }
    }
}
