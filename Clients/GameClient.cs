using System.Text.Json;
using BattleGameWeb.Dtos;
using BattleGameWeb.Configurations;
using Microsoft.Extensions.Options;
using System.Text;
using System.Net.Http.Headers;

namespace BattleGameWeb.Clients;

public class GameClient
{
	private readonly HttpClient _httpClient;
	const string Endpoint = "Game";

	public GameClient(HttpClient httpClient, IOptions<ServiceUrlConfig> config)
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

	public Task<GameDto[]?> FindAll()
		=> _httpClient.GetFromJsonAsync<GameDto[]>(Endpoint);

	public async Task<int?> Create(GameInputDto input)
	{
		var result = await _httpClient.PostAsJsonAsync(Endpoint, input);

		if (!result.IsSuccessStatusCode)
			throw new Exception(await result.Content.ReadAsStringAsync());

        var location = result.Headers.Location;
        if (location is null)
            return null;
        var lastSlash = location.OriginalString.LastIndexOf('/');
        var success = int.TryParse(location?.OriginalString.Substring(lastSlash + 1), out var id);
        return success ? id : null;
    }



}

