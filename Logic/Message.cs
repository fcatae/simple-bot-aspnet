using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class Message
    {
        public string From { get; }
        public string To { get; }
        public string Text { get; }

        public Message(string from, string to, string text)
        {
            this.From = from;
            this.To = to;
            this.Text = text;
        }
    }
}