using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusyBot.Services
{
    public interface IGraphAuthenticationService
    {
        string GetAccessToken();
    }
}
