using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.WebUtilities;

using TaxCalculator.Api.DTOs.Rate;
using TaxCalculator.Api.DTOs.Tax;

namespace TaxCalculator.Api.Services;

public interface ITaxJarApiClient
{
    public Task<TaxResponse> CalculateTaxes(TaxRequest taxRequest);
    public Task<RateResponse> GetTaxRate(RateRequest rateRequest);
}

public class TaxJarApiClient : ITaxJarApiClient
{
    private readonly HttpClient _client;
    private readonly IConfiguration _config;
    private JsonSerializerOptions _jsonOptions = new JsonSerializerOptions();

    public TaxJarApiClient(HttpClient client, IConfiguration config)
    {
        _client = client;
        _config = config;

        _client.BaseAddress = new Uri(_config["TaxJarApiUrl"]);
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config["TaxJarApiKey"]);

        _jsonOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        _jsonOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
    }

    public async Task<TaxResponse> CalculateTaxes(TaxRequest taxRequest)
    {
        var json = JsonSerializer.Serialize(taxRequest, _jsonOptions);
        var content = new StringContent(json);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await _client.PostAsync("/v2/taxes", content);
        var responseString = await response.Content.ReadAsStringAsync();
        var taxResponse = JsonSerializer.Deserialize<TaxResponse>(responseString, _jsonOptions);

        return taxResponse ?? throw new Exception("Response from TaxJar was null after deserialization");
    }

    public async Task<RateResponse> GetTaxRate(RateRequest rateRequest)
    {
        var json = JsonSerializer.Serialize(rateRequest, _jsonOptions);
        var content = new StringContent(json);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var url = QueryHelpers.AddQueryString($"/v2/rates/{rateRequest.Zip}", rateRequest.ToDictionary());
        var response = await _client.GetAsync(url);
        var responseString = await response.Content.ReadAsStringAsync();
        var rateResponse = JsonSerializer.Deserialize<RateResponse>(responseString, _jsonOptions);

        return rateResponse ?? throw new Exception("Response from TaxJar was null after deserialization");
    }
}