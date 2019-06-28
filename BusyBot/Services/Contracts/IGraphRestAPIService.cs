using Microsoft.Graph;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusyBot.Services
{
    [Headers("Authorization: Bearer")]
    public interface IGraphRestAPIService
    {
        [Get("/v1.0/users/?$filter=" +
            "startswith(displayName,'{searchName}') " +
            "or startswith(givenName,'{searchName}') " +
            "or startswith(surname,'{searchName}') " +
            "or startswith(mail,'{searchName}') " +
            "or startswith(userPrincipalName,'{searchName}')")]
        Task<IEnumerable<User>> FindUser(string searchName);

        [Get("/v1.0/users/{userId}")]
        Task<User> GetUser(string userId);

        [Get("/v1.0/users/{userId}/events/$filter=start/dateTime lt '{date}' and end/dateTime gt '{date}'")]
        Task<IEnumerable<Event>> FindCurrentEvents(string userId, DateTime date);

        [Get("/v1.0/users/{userId}/events/$filter=start/dateTime ge '{date}'&$top={count}")]
        Task<IEnumerable<Event>> FindUpcomingEvents(string userId, DateTime after, int count);

        [Get("/v1.0/users/{userId}/events/{eventId}")]
        Task<Event> GetEvent(string userId, string eventId);
    }
}
