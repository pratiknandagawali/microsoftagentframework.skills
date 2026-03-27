using System.Text;
using System.Text.Json;

public class FoundryLLMService
{
    private readonly HttpClient _http;

    public FoundryLLMService(HttpClient http)
    {
        _http = http;
    }

    public async Task<string> Ask(string prompt)
    {
        var request = new
        {
            model = "Phi-4-mini-instruct-generic-cpu:5",
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        };

        var content = new StringContent(
            JsonSerializer.Serialize(request),
            Encoding.UTF8,
            "application/json");

        var response = await _http.PostAsync(
            "http://localhost:55676/v1/chat/completions",
            content);

        return await response.Content.ReadAsStringAsync();
    }
}