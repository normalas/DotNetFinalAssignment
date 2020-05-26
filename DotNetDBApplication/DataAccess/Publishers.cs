using DotNet.Models;
using Newtonsoft.Json;
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

        public async Task<Publisher[]> GetPublishersAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync(publishersBaseUri);
            string json = await result.Content.ReadAsStringAsync();
            Publisher[] publishers = JsonConvert.DeserializeObject<Publisher[]>(json);

            return publishers;
        }

        internal async Task<bool> AddPublisherAsync(Publisher publisher)
        {
            string json = JsonConvert.SerializeObject(publisher);
            HttpResponseMessage result = await _httpClient.PostAsync(publishersBaseUri, new StringContent(json, Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {
                json = await result.Content.ReadAsStringAsync();
                var returnedPublisher = JsonConvert.DeserializeObject<Publisher>(json);
                publisher.PublisherId = returnedPublisher.PublisherId;

                return true;
            }
            else
            {
                return false;
            }
        }

        internal async Task<bool> UpdatePublisherAsync(Publisher publisher)
        {
            string json = JsonConvert.SerializeObject(publisher);
            HttpResponseMessage result = await _httpClient.PutAsync(publishersBaseUri, new StringContent(json, Encoding.UTF8, "appliction/json"));

            if (result.IsSuccessStatusCode)
            {
                json = await result.Content.ReadAsStringAsync();
                var returnedPublisher = JsonConvert.DeserializeObject<Publisher>(json);
                publisher.PublisherId = returnedPublisher.PublisherId;

                return true;
            }
            else
            {
                return false;
            }
        }

        internal async Task<bool> DeletePublisherAsync(Publisher publisher)
        {
            HttpResponseMessage result = await _httpClient.DeleteAsync(new Uri(publishersBaseUri, "publisher/" + publisher.PublisherId.ToString()));
            return result.IsSuccessStatusCode;
        }
    }
}
