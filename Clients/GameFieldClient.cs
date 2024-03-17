using System.Text.Json;
using BattleGameWeb.Dtos;
using BattleGameWeb.Configurations;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;

namespace BattleGameWeb.Clients;

public class GameFieldClient
{
	private readonly HttpClient _httpClient;
	const string Endpoint = "GameField";

	public GameFieldClient(HttpClient httpClient, IOptions<ServiceUrlConfig> config)
	{
        _httpClient = httpClient;
		_httpClient.BaseAddress = new Uri(config.Value.GameService);

        var autenticationString = "JanBenda:Password123";
        var base64EncodedAuthenticationString = Convert.ToBase64String(
            Encoding.UTF8.GetBytes(autenticationString));

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
    }

	//public Task<GameDto?> Find(int id)
	//	=> _httpClient.GetFromJsonAsync<GameDto>($"{Endpoint}/{id}");

	public Task<GameFieldDto[]?> GetAll(int gameId)
		=> _httpClient.GetFromJsonAsync<GameFieldDto[]>($"{Endpoint}/{gameId}");

	public async Task<string> Selected(GameFieldInputDto input)
    {
		var result = await _httpClient.PutAsJsonAsync(Endpoint, input);

		if (!result.IsSuccessStatusCode)
			throw new Exception(await result.Content.ReadAsStringAsync());

		return await result.Content.ReadAsStringAsync();
    }

}

