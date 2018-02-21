using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class SimpleBotUser
    {
        public static string Reply(Message message)
        {
            return $"Usuário {message.From} disse '{message.Text}'";
        }
    }
}