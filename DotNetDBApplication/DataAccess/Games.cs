using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDBApplication.DataAccess
{
    public class Games
    {
        readonly HttpClient _httpClient = new HttpClient();
        static readonly Uri gamesBaseUri = new Uri("http://localhost:6289/api/games");
    }
}
