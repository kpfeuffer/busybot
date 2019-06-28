using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Teams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace BusyBot.Services
{
    public interface IMessagingExtensionService
    {
        Task<HttpResponseMessage> HandleInvokeRequest(HttpRequestMessage request, Activity activity, CancellationToken cancellationToken = default);

        Task<HttpResponseMessage> HandleQueryAction(HttpRequestMessage request, ComposeExtensionQuery extensionQueryData, CancellationToken cancellation = default);

    }
}