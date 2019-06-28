using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusyBot.Services;
using Microsoft.Graph;
using Microsoft.Bot.Connector.Teams;
using Microsoft.Identity.Client;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Threading.Tasks;

namespace BusyBot.Repositories
{
    public class GraphUserRepository : IGraphUserRepository
    {
        private readonly IGraphRestAPIService graphService;
        public GraphUserRepository(
                IGraphRestAPIService graphService
            )
        {
            this.graphService = graphService;
        }

        public async Task<IEnumerable<User>> FindUser(string name)
        {
            return await this.graphService.FindUser(name);
        }

        public async Task<User> GetUser(string id)
        {
            return await this.graphService.GetUser(id);
        }
    }
}