namespace BusyBot.Controllers
{
    using BusyBot.Models;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    public class ClientApiController : ApiController
    {
        public ClientApiController()
        {

        }

        [HttpGet]
        [Route("api/app")]
        public IHttpActionResult GetAppInfo()
        {
            return Ok(new
            {
                appId = ConfigurationManager.AppSettings["TeamsAppId"],
                botId = ConfigurationManager.AppSettings["MicrosoftAppId"]
            });
        }

        [HttpPost]
        [Route("api/user/find")]
        public Guid FindUsers([FromBody] string userName)
        {
            return Guid.NewGuid();
        }

        [HttpGet]
        [Route("api/user/{userId}/event/current")]
        [Route("api/user/{userId}/event")]
        public Event GetCurrentEvent([FromUri] string id)
        {
            return new Event();
        }

        [HttpGet]
        [Route("api/users/{userId}/event/at/{dateString}")]
        public Event GetEventAt([FromUri] string userId, [FromUri] string dateString)
        {
            return new Event();
        }
    }
}
