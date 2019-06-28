using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using BusyBot.Domain.Readers;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Teams.Models;

namespace BusyBot.Services.Implementations
{
    public class MessagingExtensionActionService : IMessagingExtensionActionService
    {

        public Task<HttpResponseMessage> HandleFetchAction(HttpRequestMessage request, string command)
        {
            throw new NotImplementedException();
        }
        
        public Task<HttpResponseMessage> HandleSubmitAction(HttpRequestMessage request, Activity activity, CancellationToken cancellation = default)
        {
            //request.Headers.Authorization
            return Task.FromResult(request.CreateResponse(HttpStatusCode.NoContent));
        }

    }
}