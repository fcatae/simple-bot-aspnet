using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class SimpleBotUser
    {
        static Dictionary<string, UserProfile> _perfil = new Dictionary<string, UserProfile>();

        public static string Reply(Message message)
        {
            string userId = message.Id;

            var perfil = GetProfile(userId);

            perfil.Visitas += 1;

            SetProfile(userId, perfil);

            return $"{message.User} conversou {perfil.Visitas} vezes";
        }
        public static void SalvarHistorico(Message message)
        {
            var cliente = new MongoClient();
            var db = cliente.GetDatabase("bot");
            var col = db.GetCollection<BsonDocument>("historico");

            var doc = new BsonDocument
            {
                { "User", message.User },
                { "Text", message.Text }
            };

            col.InsertOne(doc);
        }

        public static UserProfile GetProfile(string id)
        {
            if(_perfil.ContainsKey(id))
                return _perfil[id];

            return new UserProfile
            {
                Id = id,
                Visitas = 0
            };
        }

        public static void SetProfile(string id, UserProfile profile)
        {
            _perfil[id] = profile;
        }
    }
}