using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusyBot.Domain.Readers
{
    public interface IUserReader
    {
        Task<IEnumerable<User>> FindUser(string name);

        Task<User> GetUser(string id);
    }
}
