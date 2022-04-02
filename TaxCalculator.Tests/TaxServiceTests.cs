using System.Threading.Tasks;

using Moq;

using Xunit;

using TaxCalculator.Api.DTOs.Tax;
using TaxCalculator.Api.Services;

using TaxCalculator.Api.DTOs.Rate;

namespace TaxCalculator.Tests;

public class TaxserviceTests
{
    [Fact]
    public void CalculateTaxes_Calls_TaxCalculator()
    {
        //Arrange
        var taxCalculatorMock = new Mock<ITaxCalculator>();
        taxCalculatorMock.Setup(x => x.CalculateTaxes(It.IsAny<TaxRequest>()))
            .ReturnsAsync(new Tax());

        var factoryMock = new Mock<ITaxCalculatorFactory>();
        factoryMock.Setup(x => x.GetTaxCalculator(It.IsAny<string>())).Returns(taxCalculatorMock.Object);

        var taxService = new TaxService(factoryMock.Object);

        //Act
        var result = taxService.CalculateTaxes(string.Empty, new TaxRequest());

        //Assert
        taxCalculatorMock.Verify(x => x.CalculateTaxes(It.IsAny<TaxRequest>()), Times.Once);
    }

    [Fact]
    public async Task CalculateTaxesAsync_Calls_TaxCalculator()
    {
        //Arrange
        var taxCalculatorMock = new Mock<ITaxCalculator>();
        taxCalculatorMock.Setup(x => x.CalculateTaxes(It.IsAny<TaxRequest>()))
            .ReturnsAsync(new Tax());

        var factoryMock = new Mock<ITaxCalculatorFactory>();
        factoryMock.Setup(x => x.GetTaxCalculator(It.IsAny<string>())).Returns(taxCalculatorMock.Object);

        var taxService = new TaxService(factoryMock.Object);

        //Act
        var result = await taxService.CalculateTaxesAsync(string.Empty, new TaxRequest());

        //Assert
        taxCalculatorMock.Verify(x => x.CalculateTaxes(It.IsAny<TaxRequest>()), Times.Once);
    }

    [Fact]
    public void GetTaxRate_Calls_TaxCalculator()
    {
        //Arrange
        var taxCalculatorMock = new Mock<ITaxCalculator>();
        taxCalculatorMock.Setup(x => x.GetTaxRate(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(new Rate());

        var factoryMock = new Mock<ITaxCalculatorFactory>();
        factoryMock.Setup(x => x.GetTaxCalculator(It.IsAny<string>())).Returns(taxCalculatorMock.Object);

        var taxService = new TaxService(factoryMock.Object);

        //Act
        var result = taxService.GetTaxRate(string.Empty, zipCode: "90404", city: "Santa Monica", state: "CA", country: "US");

        //Assert
        taxCalculatorMock.Verify(x => x.GetTaxRate(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task GetTaxRateAsync_Calls_TaxCalculator()
    {
        //Arrange
        var taxCalculatorMock = new Mock<ITaxCalculator>();
        taxCalculatorMock.Setup(x => x.GetTaxRate(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(new Rate());

        var factoryMock = new Mock<ITaxCalculatorFactory>();
        factoryMock.Setup(x => x.GetTaxCalculator(It.IsAny<string>())).Returns(taxCalculatorMock.Object);

        var taxService = new TaxService(factoryMock.Object);

        //Act
        var result = await taxService.GetTaxRateAsync(string.Empty, zipCode: "90404", city: "Santa Monica", state: "CA", country: "US");

        //Assert
        taxCalculatorMock.Verify(x => x.GetTaxRate(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }
}