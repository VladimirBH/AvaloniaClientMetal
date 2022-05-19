using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace AvaloniaClientMetal.Models;

public class UserImplementation
{
    public async Task<TokenPair> UserAuthorization(string login, string password)
    {
        HttpClient httpClient = new HttpClient();
        var values = new Dictionary<string, string>
        {
            { "login", login },
            { "password", password }
        };
        
        var content = new FormUrlEncodedContent(values);
        var response = await httpClient.PostAsync("https://localhost:7019/api/User/signin", content);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var text = response.Content.ReadAsStringAsync();
            
        }
        else
        {
            throw new AuthenticationException();
        }
    }
}