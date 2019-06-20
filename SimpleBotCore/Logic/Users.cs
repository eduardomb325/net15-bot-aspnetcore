using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Logic
{
    public class Users
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set;}

        [BsonElement("UserId")]
        public string UserId { get; set; }

        [BsonElement("User")]
        public string User { get; set; }

        [BsonElement("MessagesCount")]
        public int? MessagesCount { get; set; }

        public Users(string userId, string username, int? messagesCount)
        {
            UserId = userId;
            User = username;
            MessagesCount = messagesCount;
        }
    }
}
