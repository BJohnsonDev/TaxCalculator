using TaxCalculator.Api.DTOs.Rate;
using TaxCalculator.Api.DTOs.Tax;

namespace TaxCalculator.Api.Services;

public interface ITaxService
{
    public Tax CalculateTaxes(string? customerId, TaxRequest taxRequest);
    public Task<Tax> CalculateTaxesAsync(string customerId, TaxRequest taxRequest);
    public Rate GetTaxRate(string customerId, string zipCode, string? state = null, string? city = null, string? street = null, string? country = null);
    public Task<Rate> GetTaxRateAsync(string customerId, string zipCode, string? state = null, string? city = null, string? street = null, string? country = null);
}

public class TaxService : ITaxService
{
    private readonly ITaxCalculatorFactory _taxCalculatorFactory;

    public TaxService(ITaxCalculatorFactory taxCalculatorFactory)
    {
        _taxCalculatorFactory = taxCalculatorFactory;
    }

    public Tax CalculateTaxes(string? customerId, TaxRequest taxRequest)
    {
        return CalculateTaxesAsync(customerId, taxRequest).GetAwaiter().GetResult();
    }

    public Task<Tax> CalculateTaxesAsync(string? customerId, TaxRequest taxRequest)
    {
        var taxCalculator = _taxCalculatorFactory.GetTaxCalculator(customerId);
        return taxCalculator.CalculateTaxes(taxRequest);
    }

    public Rate GetTaxRate(string customerId, string zipCode, string? state = null, string? city = null, string? street = null, string? country = null)
    {
        return GetTaxRateAsync(customerId, zipCode, state, city, street, country).GetAwaiter().GetResult();
    }

    public Task<Rate> GetTaxRateAsync(string customerId, string zipCode, string? state = null, string? city = null, string? street = null, string? country = null)
    {
        var taxCalculator = _taxCalculatorFactory.GetTaxCalculator(customerId);
        return taxCalculator.GetTaxRate(zipCode, state, city, street, country);
    }
}