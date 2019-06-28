using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusyBot.Models.Commands
{
    public class GetCurrentEventsCommand: ActionCommandBase
    {
        [JsonProperty("userId")]
        public string UserId{ get; set; }
    }
}