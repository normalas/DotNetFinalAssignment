using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDBApplication.DataAccess
{
    public class Developers
    {
        readonly HttpClient _httpClient = new HttpClient();
        static readonly Uri developersBaseUri = new Uri("http://localhost:6289/api/developers");
    }
}
