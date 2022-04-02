using Microsoft.AspNetCore.Mvc;

using TaxCalculator.Api.DTOs.Rate;
using TaxCalculator.Api.DTOs.Tax;
using TaxCalculator.Api.Services;

// Barebones API controller to provide a means of testing and interacting with TaxService.

namespace TaxCalculator.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaxServiceController : ControllerBase
{
    private readonly ITaxService _taxService;

    public TaxServiceController(ITaxService taxService)
    {
        _taxService = taxService;
    }

    [HttpGet("GetTaxRate")]
    public Task<Rate> Get(string zipCode, string? state = null, string? city = null, string? street = null, string? country = null)
    {
        var customerId = string.Empty;
        return _taxService.GetTaxRateAsync(customerId, zipCode, state, city, street, country);
    }

    [HttpPost("CalculateTaxes")]
    public Task<Tax> Post(TaxRequest taxRequest)
    {
        var customerId = string.Empty;
        return _taxService.CalculateTaxesAsync(customerId, taxRequest);
    }
}
