using DotNet.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDBApplication.DataAccess
{
    public class VideoGames
    {
        readonly HttpClient _httpClient = new HttpClient();
        static readonly Uri videoGamesBaseUri = new Uri("http://localhost:53848/api/videoGames");

        public async Task<VideoGame[]> GetVideoGamesAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync(videoGamesBaseUri);
            string json = await result.Content.ReadAsStringAsync();
            VideoGame[] videoGames = JsonConvert.DeserializeObject<VideoGame[]>(json);

            return videoGames;
        }
        public async Task<VideoGame> GetVideoGameAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync(videoGamesBaseUri);
            string json = await result.Content.ReadAsStringAsync();
            VideoGame videoGame = JsonConvert.DeserializeObject<VideoGame>(json);

            return videoGame;
        }

        internal async Task<bool> AddVideoGameAsync(VideoGame videoGame)
        {
            string json = JsonConvert.SerializeObject(videoGame);
            HttpResponseMessage result = await _httpClient.PostAsync(videoGamesBaseUri, new StringContent(json, Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {
                json = await result.Content.ReadAsStringAsync();
                var returnedVideoGame = JsonConvert.DeserializeObject<VideoGame>(json);
                videoGame.GameId = returnedVideoGame.GameId;

                return true;
            }
            else
            {
                return false;
            }
        }

        internal async Task<bool> UpdateVideoGameAsync(VideoGame videoGame)
        {
            string json = JsonConvert.SerializeObject(videoGame);
            HttpResponseMessage result = await _httpClient.PutAsync(videoGamesBaseUri, new StringContent(json, Encoding.UTF8, "appliction/json"));

            if (result.IsSuccessStatusCode)
            {
                json = await result.Content.ReadAsStringAsync();
                var returnedVideoGame = JsonConvert.DeserializeObject<VideoGame>(json);
                videoGame.GameId = returnedVideoGame.GameId;

                return true;
            }
            else
            {
                return false;
            }
        }

        internal async Task<bool> DeleteVideoGameAsync(VideoGame videoGame)
        {
            HttpResponseMessage result = await _httpClient.DeleteAsync(new Uri(videoGamesBaseUri, "videoGame/" + videoGame.GameId.ToString()));
            return result.IsSuccessStatusCode;
        }
    }
}
