namespace TaxCalculator.Api.Services;

public interface ITaxCalculatorFactory
{
    ITaxCalculator GetTaxCalculator(string? customerId = null);
}

public class TaxCalculatorFactory : ITaxCalculatorFactory
{
    private readonly IServiceProvider _serviceProvider;

    public TaxCalculatorFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Returns an instance of ITaxCalculator based on the customer that is consuming the service
    /// </summary>
    /// <param name="customerId">A string used to identify the customer</param>
    /// <returns>An instance of ITaxCalculator</returns>
    /// <remarks>
    /// <paramref name="customerId"/> is currently unused as there is only one implementation of ITaxCalculator
    /// </remarks
    public ITaxCalculator GetTaxCalculator(string? customerId)
    {
        return _serviceProvider.GetRequiredService<TaxJarCalculator>();
    }
}
