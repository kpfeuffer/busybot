using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusyBot.Commands
{
    public class QueryCommands : IQueryCommands
    {
        public string GetEvents { get; } = "getEvents";

        public string FindUsers { get; } = "findUsers";
    }

    public interface IQueryCommands
    {
        string GetEvents { get; }
        string FindUsers {get;}
    }
}