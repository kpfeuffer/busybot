using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaptiveCards;
using Microsoft.Graph;

namespace BusyBot.Services
{
    public interface ITemplateService
    {
        IEnumerable<AdaptiveCard> CurrentEvents(IEnumerable<Event> events);

        IEnumerable<AdaptiveCard> FoundUsers(IEnumerable<User> user);
    }
}
