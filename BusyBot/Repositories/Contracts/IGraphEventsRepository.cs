using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusyBot.Repositories
{
    public interface IGraphEventsRepository
    {
        Task<IEnumerable<Event>> GetEventAt(string userId, DateTime eventTime);

        Task<IEnumerable<Event>> GetEventsAfter(string userId, DateTime earliestTime, int count = 5);

        Task<Event> GetSpecificEvent(string userId, string eventId);
    }
}
