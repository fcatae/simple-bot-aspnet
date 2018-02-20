using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;

namespace SimpleBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        [ResponseType(typeof(void))]
        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            if ( activity != null && activity.Type == ActivityTypes.Message)
            {
                await HandleActivityAsync(activity);
            }

            // HTTP 202
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        async Task HandleActivityAsync(Activity activity)
        {
            string text = activity.Text;

            await ReplyUserAsync(activity, text);
        }

        async Task ReplyUserAsync(Activity message, string text)
        {
            var connector = new ConnectorClient(new Uri(message.ServiceUrl));
            var reply = message.CreateReply("Resposta: " + text);

            await connector.Conversations.ReplyToActivityAsync(reply);
        }
    }
}