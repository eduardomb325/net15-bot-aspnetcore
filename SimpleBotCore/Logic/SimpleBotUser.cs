using SimpleBotCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBotCore.Logic
{
    public class SimpleBotUser
    {
        public string Reply(SimpleMessage message)
        {
            Users user = new Users(message.Id, message.User, 0);

            DBConnect dbConnect = new DBConnect();

            dbConnect.InsertMessages(message);
            var userReturn = dbConnect.InsertUsers(user);

            return $"{message.User} disse '{message.Text}' -- Mensagens enviadas: {userReturn.MessagesCount}";
        }

    }
}