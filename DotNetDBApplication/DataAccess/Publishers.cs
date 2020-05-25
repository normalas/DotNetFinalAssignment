using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDBApplication.DataAccess
{
    public class Publishers
    {
        readonly HttpClient _httpClient = new HttpClient();
        static readonly Uri publishersBaseUri = new Uri("http://localhost:6289/api/publishers");
    }
}
