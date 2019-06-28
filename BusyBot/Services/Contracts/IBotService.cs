using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusyBot.Services
{
    public interface IBotService
    {
        Task HandleMessage(Activity activity, CancellationToken cancellationToken = default);

        Task<bool> HandleAdaptiveCardAction(Activity activity, CancellationToken cancellation = default);
    }
}
