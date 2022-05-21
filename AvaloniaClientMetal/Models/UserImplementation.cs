using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvaloniaClientMetal.Models;

public class UserImplementation
{
    public async Task<TokenPair> UserAuthorization(DataAuth dataAuth)
    {
        var httpClient = new HttpClient();
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        options.Converters.Add(new JsonStringEnumConverter());
        var response = await httpClient.PostAsJsonAsync("https://localhost:7019/api/User/signin", dataAuth, options);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var text = await response.Content.ReadAsStringAsync();
            TokenPair tokenPair = JsonSerializer.Deserialize<TokenPair>(text);
            if (tokenPair != null)
            {
                return tokenPair;
            }
            else
            {
                throw new JsonException("Произошла ошибка");
            }
        }
        else
        {
            throw new AuthenticationException("Неверный логин/пароль");
        }
    }
}