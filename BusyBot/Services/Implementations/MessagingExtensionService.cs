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
using BusyBot.Extensions;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Teams;
using Microsoft.Bot.Connector.Teams.Models;
using Refit;

namespace BusyBot.Services
{
    public class MessagingExtensionService : IMessagingExtensionService
    {
        private readonly IMapper mapper;
        private readonly IEventReader eventReader;
        public MessagingExtensionService(
                IMapper mapper,
                IEventReader eventReader
            )
        {
            this.mapper = mapper;
            this.eventReader = eventReader;
        }
        public async Task<HttpResponseMessage> HandleInvokeRequest(HttpRequestMessage request, Activity activity, CancellationToken cancellationToken = default)
        {
            var extensionQueryData = activity.GetComposeExtensionQueryData();
            if (extensionQueryData?.CommandId == null)
            {
                return request.CreateResponse(HttpStatusCode.NotAcceptable);
            }

            if(activity.IsFetchTask())
            {

            }

            return request.CreateResponse(HttpStatusCode.NotFound);
        }

        public async Task<HttpResponseMessage> HandleQueryAction(HttpRequestMessage request, ComposeExtensionQuery extensionQueryData, CancellationToken cancellation = default)
        {
            if (extensionQueryData.Parameters == null)
            {
                return request.CreateResponse(HttpStatusCode.NoContent);
            }

            var isInitialRun = false;
            var initialRunParameter = GetQueryParameterByName(extensionQueryData, "initialRun");

            // situation where the incoming payload was received from the config popup
            if (!string.IsNullOrEmpty(extensionQueryData.State))
            {
                initialRunParameter = "true";
            }

            if (string.Equals(initialRunParameter, "true", StringComparison.OrdinalIgnoreCase))
            {
                isInitialRun = true;
            }

            var maxResults = extensionQueryData.QueryOptions.Count ?? 25;
            if (isInitialRun) maxResults = 5;

            var attachments = new List<ComposeExtensionAttachment>();



            //var searchText = GetQueryParameterByName(extensionQueryData, "searchText");

            var currentUser = GetQueryParameterByName(extensionQueryData, "userId");

            var graphService= RestService.For<IGraphRestAPIService>(
                new HttpClient(new AuthenticatedHttpClientHandler(request.Headers.Authorization.Parameter))
                {
                    BaseAddress = new Uri("https://graph.microsoft.com")
                });

            var events = graphService.FindCurrentEvents(currentUser, DateTime.Now);

            attachments = this.mapper.Map<List<ComposeExtensionAttachment>>(events);

            var response = new ComposeExtensionResponse
            {
                ComposeExtension = new ComposeExtensionResult
                {
                    Type = "result",
                    Attachments = attachments,
                    AttachmentLayout = AttachmentLayoutTypes.List
                }
            };


            return request.CreateResponse(HttpStatusCode.OK, response);
        }

        private string GetQueryParameterByName(ComposeExtensionQuery query, string name)
        {
            if (query?.Parameters == null || query.Parameters.Count == 0)
            {
                return string.Empty;
            }

            var parameter = query.Parameters[0];
            if (!string.Equals(parameter.Name, name, StringComparison.OrdinalIgnoreCase))
            {
                return string.Empty;
            }

            return parameter.Value != null ? parameter.Value.ToString() : string.Empty;
        }
    }
}