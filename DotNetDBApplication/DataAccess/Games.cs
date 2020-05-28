using DotNet.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDBApplication.DataAccess
{
    public class Games
    {
        readonly HttpClient _httpClient = new HttpClient();
        static readonly Uri gamesBaseUri = new Uri("http://localhost:53848/api/games");

        public async Task<Game[]> GetGamesAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync(gamesBaseUri);
            string json = await result.Content.ReadAsStringAsync();
            Game[] games = JsonConvert.DeserializeObject<Game[]>(json);

            return games;
        }

        internal async Task<bool> AddGameAsync(Game game)
        {
            string json = JsonConvert.SerializeObject(game);
            HttpResponseMessage result = await _httpClient.PostAsync(gamesBaseUri, new StringContent(json, Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {
                json = await result.Content.ReadAsStringAsync();
                var returnedGame = JsonConvert.DeserializeObject<Game>(json);
                game.GameId = returnedGame.GameId;

                return true;
            }
            else
            {
                return false;
            }
        }

        internal async Task<bool> UpdateGameAsync(Game game)
        {
            string json = JsonConvert.SerializeObject(game);
            HttpResponseMessage result = await _httpClient.PutAsync(new Uri(gamesBaseUri, "game/" + game.GameId.ToString()), new StringContent(json, Encoding.UTF8, "appliction/json"));

            if (result.IsSuccessStatusCode)
            {
                json = await result.Content.ReadAsStringAsync();
                var returnedGame = JsonConvert.DeserializeObject<Game>(json);
                game.GameId = returnedGame.GameId;

                return true;
            }
            else
            {
                return false;
            }
        }

        internal async Task<bool> DeleteGameAsync(Game game)
        {
            HttpResponseMessage result = await _httpClient.DeleteAsync(new Uri(gamesBaseUri, "game/" + game.GameId.ToString()));
            return result.IsSuccessStatusCode;
        }
    }
}
