using BusyBot.Extensions;
using BusyBot.Services;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace BusyBot.Controllers
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private IBotService botService;
        public MessagesController(
                IBotService botService
            )
        {
            this.botService = botService;
        }

        [HttpPost]
        [Route("api/messages")]
        public async Task<HttpResponseMessage> Post([FromBody] Activity activity, CancellationToken cancellation)
        {
            if (activity is null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            if (activity.IsAdaptiveCardActionQuery())
            {
                var isHandled = await botService.HandleAdaptiveCardAction(activity, cancellation);
                if (isHandled)
                {
                    return Request.CreateResponse(HttpStatusCode.Accepted);
                }
            }

            switch (activity.GetActivityType())
            {
                //case ActivityTypes.ConversationUpdate:
                //    await botService.HandleConversationUpdate(activity, cancellation);
                //    break;

                case ActivityTypes.Message:
                    await botService.HandleMessage(activity, cancellation);
                    break;

                case ActivityTypes.Invoke:
                    return await HandleInvoke(activity, cancellation);
            }

            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
        private async Task<HttpResponseMessage> HandleInvoke(Activity activity, CancellationToken cancellationToken)
        {
            //if (activity.IsSigninStateVerificationQuery())
            //{
            //    await _botService.HandleMessage(activity, cancellationToken);
            //}

            //if (activity.IsComposeExtensionQuery())
            //{
            //    return await _messagingExtensionService.HandleInvokeRequest(Request, activity, cancellationToken);
            //}

            //if (activity.IsFileConsentCardResponse())
            //{
            //    await _botService.HandleFileConsentResponse(activity, cancellationToken);
            //}

            // Return empty response.
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
