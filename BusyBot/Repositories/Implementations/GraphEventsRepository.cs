using BusyBot.Services;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusyBot.Repositories
{
    public class GraphEventsRepository: IGraphEventsRepository
    {
        private readonly IGraphRestAPIService graphService;
        public GraphEventsRepository(
                IGraphRestAPIService graphService
            )
        {
            this.graphService = graphService;
        }

        public async Task<IEnumerable<Event>> GetEventAt(string userId, DateTime eventTime)
        {
            return await this.graphService.FindCurrentEvents(userId, eventTime);
        }

        public async Task<IEnumerable<Event>> GetEventsAfter(string userId, DateTime earliestTime, int count = 5)
        {
            return await this.graphService.FindUpcomingEvents(userId, earliestTime, count);
        }

        public async Task<Event> GetSpecificEvent(string userId, string eventId)
        {
            return await this.graphService.GetEvent(userId, eventId);
        }
    }
}
