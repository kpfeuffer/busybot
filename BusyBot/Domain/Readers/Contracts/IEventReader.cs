using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusyBot.Domain.Readers
{
    public interface IEventReader
    {
        Task<IEnumerable<Event>> GetCurrentEvents(string userId);

        Task<IEnumerable<Event>> GetEventsAt(string userId, DateTime eventTime);
    }
}
