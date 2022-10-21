using SharedHelpers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Webbgame.UI.Services
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _client;

        public RequestService(HttpClient client) => _client = client;

        public async Task<CharacterDto> GetCharacter(string email)
        {
            var respons = await _client.GetFromJsonAsync<CharacterDto>($"api/character/email?email={email}");
            //var character = (await respons.Content.ReadFromJsonAsync<CharacterDto>());
            return respons!;
        }
        public async Task<CharacterDto> CreateCharacter(CharacterForCreationDto character)
        {
            var respons = await _client.PostAsJsonAsync("api/character/", character);
            var newCharacter = (await respons.Content.ReadFromJsonAsync<CharacterDto>());
            return newCharacter!;
        }

    }
}
