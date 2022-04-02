using Microsoft.Extensions.Primitives;

namespace TaxCalculator.Api.DTOs.Rate;

public class RateRequest
{
    public RateRequest(string zip, string? state, string? city, string? street, string? country)
    {
        Zip = zip;
        State = state;
        City = city;
        Street = street;
        Country = country;
    }

    public string Zip { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? Country { get; set; }

    // Convert object to dictionary, for easier query string building
    // Zip is excluded as it is a route parameter, not a query string parameter
    internal Dictionary<string, string?> ToDictionary()
    {
        var dict = new Dictionary<string, string?>
        {
            { "State", State },
            { "City", City },
            { "Street", Street },
            { "Country", Country }
        };
        return dict;
    }
}

