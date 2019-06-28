using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Graph;
using System.Text;
using System.Threading.Tasks;
using BusyBot.Repositories;

namespace BusyBot.Domain.Readers
{
    public class UserReader : IUserReader
    {
        private readonly IGraphUserRepository userRepository;
        public UserReader(
                IGraphUserRepository userRepository
            )
        {
            this.userRepository = userRepository;
        }

        public Task<IEnumerable<User>> FindUser(string name)
        {
            return this.userRepository.FindUser(name);
        }

        public Task<User> GetUser(string id)
        {
            return this.userRepository.GetUser(id);
        }
    }
}
