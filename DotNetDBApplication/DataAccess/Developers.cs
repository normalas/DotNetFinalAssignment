using DotNet.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDBApplication.DataAccess
{
    public class Developers
    {
        readonly HttpClient _httpClient = new HttpClient();
        static readonly Uri developersBaseUri = new Uri("http://localhost:53848/api/developers");

        public async Task<Developer[]> GetDevelopersAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync(developersBaseUri);
            string json = await result.Content.ReadAsStringAsync();
            Developer[] developers = JsonConvert.DeserializeObject<Developer[]>(json);

            return developers;
        }

        internal async Task<bool> AddDeveloperAsync(Developer developer)
        {
            string json = JsonConvert.SerializeObject(developer);
            HttpResponseMessage result = await _httpClient.PostAsync(developersBaseUri, new StringContent(json, Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {
                json = await result.Content.ReadAsStringAsync();
                var returnedDeveloper = JsonConvert.DeserializeObject<Developer>(json);
                developer.DeveloperId = returnedDeveloper.DeveloperId;

                return true;
            }
            else
            {
                return false;
            }
        }

        internal async Task<bool> UpdateDeveloperAsync(Developer developer)
        {
            string json = JsonConvert.SerializeObject(developer);
            HttpResponseMessage result = await _httpClient.PutAsync(new Uri(developersBaseUri, "developer/" + developer.DeveloperId.ToString()), new StringContent(json, Encoding.UTF8, "appliction/json"));

            if (result.IsSuccessStatusCode)
            {
                json = await result.Content.ReadAsStringAsync();
                var returnedDeveloper = JsonConvert.DeserializeObject<Developer>(json);
                developer.DeveloperId = returnedDeveloper.DeveloperId;

                return true;
            }
            else
            {
                return false;
            }
        }

        internal async Task<bool> DeleteDeveloperAsync(Developer developer)
        {
            HttpResponseMessage result = await _httpClient.DeleteAsync(new Uri(developersBaseUri, "developer/" + developer.DeveloperId.ToString()));
            return result.IsSuccessStatusCode;
        }
    }
}
