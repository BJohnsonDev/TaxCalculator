using System.Text.Json.Serialization;

namespace TaxCalculator.Api.DTOs.Rate;

/// <summary>
/// Response object for TaxJar API's rates endpoint
/// </summary>
public class RateResponse
{
    [JsonPropertyName("rate")]
    public Rate? TaxRate { get; set; }
}

/// <summary>
/// Content of TaxJar's rate response object
/// </summary>
public class Rate
{
    [JsonPropertyName("zip")]
    public string? ZipCode { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("country_rate")]
    public decimal CountryRate { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("state_rate")]
    public decimal StateRate { get; set; }

    [JsonPropertyName("county")]
    public string? County { get; set; }

    [JsonPropertyName("county_rate")]
    public decimal CountyRate { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("city_rate")]
    public decimal CityRate { get; set; }

    [JsonPropertyName("combined_district_rate")]
    public decimal CombinedDistrictRate { get; set; }

    [JsonPropertyName("combined_rate")]
    public decimal CombinedRate { get; set; }

    [JsonPropertyName("freight_taxable")]
    public bool FreightTaxable { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("standard_rate")]
    public decimal? StandardRate { get; set; }

    [JsonPropertyName("reduced_rate")]
    public decimal? ReducedRate { get; set; }

    [JsonPropertyName("super_reduced_rate")]
    public decimal? SuperReducedRate { get; set; }

    [JsonPropertyName("parking_rate")]
    public decimal? ParkingRate { get; set; }

    [JsonPropertyName("distance_sale_threshold")]
    public decimal? DistanceSaleThreshold { get; set; }
}

