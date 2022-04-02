using TaxCalculator.Api.DTOs.Rate;
using TaxCalculator.Api.DTOs.Tax;

namespace TaxCalculator.Api.Services;

public interface ITaxCalculator
{
    public Task<Tax> CalculateTaxes(TaxRequest taxRequest);
    public Task<Rate> GetTaxRate(string zipCode, string? state, string? city, string? street, string? country);
}