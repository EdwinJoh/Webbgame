using SharedHelpers.DTO.CharacterDtos;

namespace WebbGame.Ui.Service;

public interface ICharacterService
{
    Task CreateCharacterRequest(CharacterForCreationDto character);
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
}