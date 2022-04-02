using System.Text.Json.Serialization;

namespace TaxCalculator.Api.DTOs.Tax;

/// <summary>
/// Request object for TaxJar's taxes endpoint
/// </summary>
public class TaxRequest
{
    [JsonPropertyName("from_country")]
    public string? FromCountry { get; set; }

    [JsonPropertyName("from_zip")]
    public string? FromZip { get; set; }

    [JsonPropertyName("from_state")]
    public string? FromState { get; set; }

    [JsonPropertyName("from_city")]
    public string? FromCity { get; set; }

    [JsonPropertyName("from_street")]
    public string? FromStreet { get; set; }

    [JsonPropertyName("to_country")]
    public string? ToCountry { get; set; }

    [JsonPropertyName("to_zip")]
    public string? ToZip { get; set; }

    [JsonPropertyName("to_state")]
    public string? ToState { get; set; }

    [JsonPropertyName("to_city")]
    public string? ToCity { get; set; }

    [JsonPropertyName("to_street")]
    public string? ToStreet { get; set; }

    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    [JsonPropertyName("shipping")]
    public decimal Shipping { get; set; }

    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    [JsonPropertyName("exemption_type")]
    public string? ExemptionType { get; set; }

    [JsonPropertyName("nexus_addresses")]
    public List<NexusAddress>? NexusAddresses { get; set; }

    [JsonPropertyName("line_items")]
    public List<RequestLineItem>? LineItems { get; set; }
}

public class NexusAddress
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("zip")]
    public string? Zip { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("street")]
    public string? Street { get; set; }
}

public class RequestLineItem
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("product_tax_code")]
    public string? ProductTaxCode { get; set; }

    [JsonPropertyName("unit_price")]
    public decimal UnitPrice { get; set; }

    [JsonPropertyName("discount")]
    public decimal Discount { get; set; }
}