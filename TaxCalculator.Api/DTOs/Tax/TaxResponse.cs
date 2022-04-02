using System.Text.Json.Serialization;

namespace TaxCalculator.Api.DTOs.Tax;

/// <summary>
/// Response object for TaxJar's taxes endpoint
/// </summary>
public class TaxResponse
{
    [JsonPropertyName("tax")]
    public Tax? Tax { get; set; }
}

/// <summary>
/// Content of TaxJar's tax response object
/// </summary>
public class Tax
{
    [JsonPropertyName("order_total_amount")]
    public decimal OrderTotalAmount { get; set; }

    [JsonPropertyName("shipping")]
    public decimal Shipping { get; set; }

    [JsonPropertyName("taxable_amount")]
    public decimal TaxableAmount { get; set; }

    [JsonPropertyName("amount_to_collect")]
    public decimal AmountToCollect { get; set; }

    [JsonPropertyName("rate")]
    public decimal Rate { get; set; }

    [JsonPropertyName("has_nexus")]
    public bool HasNexus { get; set; }

    [JsonPropertyName("freight_taxable")]
    public bool FreightTaxable { get; set; }

    [JsonPropertyName("tax_source")]
    public string? TaxSource { get; set; }

    [JsonPropertyName("exemption_type")]
    public string? ExemptionType { get; set; }

    [JsonPropertyName("jurisdictions")]
    public TaxJurisdictions? Jurisdictions { get; set; }

    [JsonPropertyName("breakdown")]
    public TaxBreakdown? Breakdown { get; set; }
}

public class TaxJurisdictions
{
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("county")]
    public string? County { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }
}


public abstract class Breakdown
{
    [JsonPropertyName("country_taxable_amount")]
    public decimal CountryTaxableAmount { get; set; }

    [JsonPropertyName("country_tax_rate")]
    public decimal CountryTaxRate { get; set; }

    [JsonPropertyName("country_tax_collectable")]
    public decimal CountryTaxCollectable { get; set; }

    // Canada
    [JsonPropertyName("gst_taxable_amount")]
    public decimal GSTTaxableAmount { get; set; }

    [JsonPropertyName("gst_tax_rate")]
    public decimal GSTTaxRate { get; set; }

    [JsonPropertyName("gst")]
    public decimal GST { get; set; }

    [JsonPropertyName("pst_taxable_amount")]
    public decimal PSTTaxableAmount { get; set; }

    [JsonPropertyName("pst_tax_rate")]
    public decimal PSTTaxRate { get; set; }

    [JsonPropertyName("pst")]
    public decimal PST { get; set; }

    [JsonPropertyName("qst_taxable_amount")]
    public decimal QSTTaxableAmount { get; set; }

    [JsonPropertyName("qst_tax_rate")]
    public decimal QSTTaxRate { get; set; }

    [JsonPropertyName("qst")]
    public decimal QST { get; set; }
}

/// <summary>
/// Breakdown of tax rates by jurisdiction
/// </summary>
public class TaxBreakdown : Breakdown
{
    [JsonPropertyName("taxable_amount")]
    public decimal TaxableAmount { get; set; }

    [JsonPropertyName("tax_collectable")]
    public decimal TaxCollectable { get; set; }

    [JsonPropertyName("combined_tax_rate")]
    public decimal CombinedTaxRate { get; set; }

    [JsonPropertyName("state_taxable_amount")]
    public decimal StateTaxableAmount { get; set; }

    [JsonPropertyName("state_tax_rate")]
    public decimal StateTaxRate { get; set; }

    [JsonPropertyName("state_tax_collectable")]
    public decimal StateTaxCollectable { get; set; }

    [JsonPropertyName("county_taxable_amount")]
    public decimal CountyTaxableAmount { get; set; }

    [JsonPropertyName("county_tax_rate")]
    public decimal CountyTaxRate { get; set; }

    [JsonPropertyName("county_tax_collectable")]
    public decimal CountyTaxCollectable { get; set; }

    [JsonPropertyName("city_taxable_amount")]
    public decimal CityTaxableAmount { get; set; }

    [JsonPropertyName("city_tax_rate")]
    public decimal CityTaxRate { get; set; }

    [JsonPropertyName("city_tax_collectable")]
    public decimal CityTaxCollectable { get; set; }

    [JsonPropertyName("special_district_taxable_amount")]
    public decimal SpecialDistrictTaxableAmount { get; set; }

    [JsonPropertyName("special_tax_rate")]
    public decimal SpecialDistrictTaxRate { get; set; }

    [JsonPropertyName("special_district_tax_collectable")]
    public decimal SpecialDistrictTaxCollectable { get; set; }

    [JsonPropertyName("shipping")]
    public TaxBreakdownShipping? Shipping { get; set; }

    [JsonPropertyName("line_items")]
    public List<TaxBreakdownLineItem>? LineItems { get; set; }

    
}

public class TaxBreakdownLineItem : Breakdown
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("state_sales_tax_rate")]
    public decimal StateSalesTaxRate { get; set; }

    [JsonPropertyName("state_amount")]
    public decimal StateAmount { get; set; }

    [JsonPropertyName("county_amount")]
    public decimal CountyAmount { get; set; }

    [JsonPropertyName("city_amount")]
    public decimal CityAmount { get; set; }

    [JsonPropertyName("special_district_taxable_amount")]
    public decimal SpecialDistrictTaxableAmount { get; set; }

    [JsonPropertyName("special_tax_rate")]
    public decimal SpecialTaxRate { get; set; }

    [JsonPropertyName("special_district_amount")]
    public decimal SpecialDistrictAmount { get; set; }
}

public class TaxBreakdownShipping : Breakdown
{
    [JsonPropertyName("state_sales_tax_rate")]
    public decimal StateSalesTaxRate { get; set; }

    [JsonPropertyName("state_amount")]
    public decimal StateAmount { get; set; }

    [JsonPropertyName("county_amount")]
    public decimal CountyAmount { get; set; }

    [JsonPropertyName("city_amount")]
    public decimal CityAmount { get; set; }

    [JsonPropertyName("special_taxable_amount")]
    public decimal SpecialDistrictTaxableAmount { get; set; }

    [JsonPropertyName("special_tax_rate")]
    public decimal SpecialDistrictTaxRate { get; set; }

    [JsonPropertyName("special_district_amount")]
    public decimal SpecialDistrictAmount { get; set; }
}

