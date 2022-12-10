using SharedHelpers.DTO.CharacterDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace WebbGame.Ui.Service;
public interface ICharacterService
{
    Task CreateCharacterRequest(CharacterForCreationDto character);
}

public class CharacterService : ICharacterService
{
    private readonly HttpClient httpClient;
    public CharacterService(HttpClient Http)
    {
        httpClient = Http;
    }


    public async Task CreateCharacterRequest(CharacterForCreationDto character)
    {
        var request = await httpClient.PostAsJsonAsync("https://localhost:5001/createCharacter", character);
    }
}
