using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBotCore.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Repository
{
    public class DBConnect
    {
        public DBConnect()
        {
                
        }
        
        public static IMongoDatabase db => GetMongoDatabase("BotCore");

        public void InsertMessages(SimpleMessage simpleMessage)
        {
            try
            {
                var bsonDocument = new BsonDocument()
                {
                    {"userId", simpleMessage.Id },
                    {"date", DateTime.Now },
                    {"message", simpleMessage.Text }
                };

                var col = db.GetCollection<BsonDocument>("messages");

                col.InsertOne(bsonDocument);

                Console.WriteLine ("Sucess Save");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Users InsertUsers(Users user)
        {
            try
            {

                var col = db.GetCollection<Users>("users");

                var filter = Builders<Users>
                                .Filter
                                .Eq(x => x.UserId, user.UserId);

                var userFound = col.Find(filter).FirstOrDefault();

                if (userFound == null)
                {
                    user.Id = ObjectId.GenerateNewId();
                    user.MessagesCount = 1;

                    col.InsertOne(user);

                    return user;
                }

                userFound.MessagesCount += 1;

                col.ReplaceOne(filter, userFound);

                return userFound;

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public static IMongoDatabase GetMongoDatabase(string database)
        {
            var client = new MongoClient("mongodb://localhost:27017");

            return client.GetDatabase(database);
        }
    }
}
