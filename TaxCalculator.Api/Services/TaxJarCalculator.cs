using TaxCalculator.Api.DTOs.Rate;
using TaxCalculator.Api.DTOs.Tax;

namespace TaxCalculator.Api.Services;

/// <summary>
/// Calculates taxes using TaxJar's API
/// </summary>
/// <remarks>
/// Currently just a passthrough. If we had multiple implementations of ITaxCalculator,
/// this class would be responsible for converting requests and responses between TaxJar's 
/// format and common types used by business logic.
/// </remarks
public class TaxJarCalculator : ITaxCalculator
{
    private readonly ITaxJarApiClient _taxJarApiClient;

    public TaxJarCalculator(ITaxJarApiClient taxJarApiClient)
    {
        _taxJarApiClient = taxJarApiClient;
    }

    public async Task<Tax> CalculateTaxes(TaxRequest taxRequest)
    {
        var response = await _taxJarApiClient.CalculateTaxes(taxRequest);
        return response.Tax!;
    }

    public async Task<Rate> GetTaxRate(string zipCode, string? state, string? city, string? street, string? country)
    {
        var rateRequest = new RateRequest(zipCode, state, city, street, country);
        var response = await _taxJarApiClient.GetTaxRate(rateRequest);
        return response.TaxRate!;
    }
}