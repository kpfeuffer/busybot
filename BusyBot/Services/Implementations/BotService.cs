using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using AdaptiveCards;
using BusyBot.Commands;
using BusyBot.Domain.Readers;
using BusyBot.Models.Commands;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;

namespace BusyBot.Services
{
    public class BotService : IBotService
    {
        private readonly IQueryCommands queryCommands;
        private readonly ITemplateService templateService;
        private readonly IEventReader eventReader;
        public BotService(
            IQueryCommands queryCommands,
            ITemplateService templateService,
            IEventReader eventReader
            )
        {
            this.queryCommands = queryCommands;
            this.templateService = templateService;
            this.eventReader = eventReader;
        }

        public async Task<bool> HandleAdaptiveCardAction(Activity activity, CancellationToken cancellation = default)
        {
            var command = JsonConvert.DeserializeObject<ActionCommandBase>(activity.Value?.ToString());
            if (string.IsNullOrEmpty(command?.CommandId))
            {
                return false;
            }

            IEnumerable<AdaptiveCard> results = null;
            if(command.CommandId == queryCommands.GetEvents) 
            {
                var events = await this.eventReader.GetCurrentEvents((command as GetCurrentEventsCommand).UserId);
                results = this.templateService.CurrentEvents(events);
            } 

            if(results is null)
            {
                return false;
            }

            var message = Activity.CreateMessageActivity();
            var client = new ConnectorClient(new Uri(activity.ServiceUrl));
            foreach(AdaptiveCard card in results)
            {
                message.Attachments.Add(new Attachment
                {
                    ContentType = AdaptiveCard.ContentType,
                    Content = card
                });
            }
            await client.Conversations.UpdateActivityAsync(activity.Conversation.Id, activity.ReplyToId, (Activity) message, cancellation);

            return true;
        }

        public Task HandleMessage(Activity activity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}