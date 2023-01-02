using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using SharedHelpers.DTO.CharacterDtos;

namespace WebbGame.Ui.Service;

public interface ICharacterService
{
    Task CreateCharacterRequest(CharacterForCreationDto character);
    Task<List<CharacterDto>> GetCharacters();
}

public class CharacterService : ICharacterService
{
    private readonly HttpClient _httpClient;

    public CharacterService(HttpClient http)
    {
        _httpClient = http;
    }


    public async Task CreateCharacterRequest(CharacterForCreationDto character)
    {
        var request = await _httpClient.PostAsJsonAsync("https://localhost:5001/createCharacter", character);
    }

    public async Task<List<CharacterDto>> GetCharacters()
    {
        var request = await _httpClient.GetFromJsonAsync<List<CharacterDto>>("https://localhost:5001/getallcharcters");
        return request!;
    }

    
}