using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaptiveCards;
using BusyBot.Commands;
using Microsoft.Bot.Connector;
using Microsoft.Graph;

namespace BusyBot.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IQueryCommands commands;

        public TemplateService(IQueryCommands commands)
        {
            this.commands = commands;

        }

        public IEnumerable<AdaptiveCard> CurrentEvents(IEnumerable<Event> events)
        {
            return events.Select(ev =>
            new AdaptiveCard(new AdaptiveSchemaVersion(1, 1))
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveTextBlock(ev.Subject)
                    {
                        Weight=AdaptiveTextWeight.Bolder,
                        Size = AdaptiveTextSize.Large
                    },
                    new AdaptiveTextBlock(ev.BodyPreview),
                    new AdaptiveFactSet
                    {
                        Facts = new List<AdaptiveFact>{
                            new AdaptiveFact("Ort", ev.Location.DisplayName),
                            new AdaptiveFact("Start",DateTime.Parse(ev.Start.DateTime).ToLocalTime().ToLongTimeString()),
                            new AdaptiveFact("Ende", DateTime.Parse(ev.End.DateTime).ToLocalTime().ToLongTimeString())
                        }
                    }
                }
            });
        }

        public IEnumerable<AdaptiveCard> FoundUsers(IEnumerable<User> users)
        {
            CardAction userAction = null;

            return users.Select(user =>
            {

                return new AdaptiveCard(new AdaptiveSchemaVersion(1, 1))
                {
                    Actions = new List<AdaptiveAction>
                {
                    new AdaptiveSubmitAction
                    {
                        Data = new CardAction
                        {
                            Title = "Nutzer wählen",
                            Value = new
                            {
                                commandId = commands.GetEvents,
                                userId = user.Id
                            }

                        },
                        
                    }
                },
                    Body = new List<AdaptiveElement>
                    {
                        new AdaptiveContainer
                        {
                            Items = new List<AdaptiveElement>
                            {
                                new AdaptiveTextBlock(user.DisplayName)
                            },
                        }
                    }
                };
            });
        }
    }

}
