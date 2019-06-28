using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusyBot.Models.Commands
{
    public class ActionCommandBase
    {
        [JsonProperty("commandId")]
        public string CommandId { get; set; }
    }
}