using Microsoft.Graph;
using BusyBot.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusyBot.Domain.Readers
{
    public class EventReader: IEventReader
    {
        private readonly IGraphEventsRepository eventsRepostiory;
        public EventReader(
                IGraphEventsRepository eventsRepostiory
            )
        {
            this.eventsRepostiory = eventsRepostiory;
        }

        public Task<IEnumerable<Event>> GetCurrentEvents(string userId)
        {
            return this.eventsRepostiory.GetEventAt(userId, DateTime.Now);
            //return new List<Event>() { new Event { Subject = "Test Event" } };
        }

        public Task<IEnumerable<Event>> GetEventsAt(string userId, DateTime eventTime)
        {
            return this.eventsRepostiory.GetEventAt(userId, eventTime);
        }
    }
}
