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
    public class Characters
    {
        readonly HttpClient _httpClient = new HttpClient();
        static readonly Uri charactersBaseUri = new Uri("http://localhost:6289/api/characters");

        public async Task<Character[]> GetCharactersAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync(charactersBaseUri);
            string json = await result.Content.ReadAsStringAsync();
            Character[] characters = JsonConvert.DeserializeObject<Character[]>(json);

            return characters;
        }

        internal async Task<bool> AddCharacterAsync(Character character)
        {
            string json = JsonConvert.SerializeObject(character);
            HttpResponseMessage result = await _httpClient.PostAsync(charactersBaseUri, new StringContent(json, Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {
                json = await result.Content.ReadAsStringAsync();
                var returnedCharacter = JsonConvert.DeserializeObject<Character>(json);
                character.CharacterId = returnedCharacter.CharacterId;

                return true;
            }
            else
            {
                return false;
            }
        }

        internal async Task<bool> UpdateCharacterAsync(Character character)
        {
            string json = JsonConvert.SerializeObject(character);
            HttpResponseMessage result = await _httpClient.PutAsync(charactersBaseUri, new StringContent(json, Encoding.UTF8, "appliction/json"));

            if (result.IsSuccessStatusCode)
            {
                json = await result.Content.ReadAsStringAsync();
                var returnedCharacter = JsonConvert.DeserializeObject<Character>(json);
                character.CharacterId = returnedCharacter.CharacterId;

                return true;
            }
            else
            {
                return false;
            }
        }

        internal async Task<bool> DeleteCharacterAsync(Character character)
        {
            HttpResponseMessage result = await _httpClient.DeleteAsync(new Uri(charactersBaseUri, "character/" + character.CharacterId.ToString()));
            return result.IsSuccessStatusCode;
        }
    }
}
