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
    public interface IMessagingExtensionActionService
    {
        Task<HttpResponseMessage> HandleFetchAction(HttpRequestMessage request, string command);
        Task<HttpResponseMessage> HandleSubmitAction(HttpRequestMessage request, Activity activity, CancellationToken cancellation = default);

    }
}