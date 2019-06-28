using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BusyBot.Repositories
{
    public interface IGraphUserRepository
    {
        Task<IEnumerable<User>> FindUser(string name);

        Task<User> GetUser(string id);
    }
}