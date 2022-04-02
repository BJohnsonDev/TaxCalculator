using System.Threading.Tasks;

using Moq;

using TaxCalculator.Api.DTOs.Rate;
using TaxCalculator.Api.DTOs.Tax;
using TaxCalculator.Api.Services;

using Xunit;

namespace TaxCalculator.Tests;

public class TaxJarCalculatorTests
{
    [Fact]
    public async Task CalculateTaxes_Calls_ApiClient()
    {
        //Arrange
        var apiClientMock = new Mock<ITaxJarApiClient>();
        apiClientMock.Setup(x => x.CalculateTaxes(It.IsAny<TaxRequest>()))
            .ReturnsAsync(new TaxResponse());

        var taxJarCalculator = new TaxJarCalculator(apiClientMock.Object);

        //Act
        var result = await taxJarCalculator.CalculateTaxes(new TaxRequest());

        //Assert
        apiClientMock.Verify(x => x.CalculateTaxes(It.IsAny<TaxRequest>()), Times.Once);
    }

    [Fact]
    public async Task GetTaxRate_Calls_ApiClient()
    {
        //Arrange
        var apiClientMock = new Mock<ITaxJarApiClient>();
        apiClientMock.Setup(x => x.GetTaxRate(It.IsAny<RateRequest>()))
            .ReturnsAsync(new RateResponse());

        var taxJarCalculator = new TaxJarCalculator(apiClientMock.Object);

        //Act
        var result = await taxJarCalculator.GetTaxRate(zipCode: "90404", city: "Santa Monica", state: "CA", street: null, country: "US");

        //Assert
        apiClientMock.Verify(x => x.GetTaxRate(It.IsAny<RateRequest>()), Times.Once);
    }
}