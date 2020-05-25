using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDBApplication.DataAccess
{
    public class Actors
    {
        readonly HttpClient _httpClient = new HttpClient();
        static readonly Uri actorsBaseUri = new Uri("http://localhost:6289/api/actors");
    }
}
