namespace DoBHttpCall.Responses.CompanyInformationResponses;

public class Sni2007IndustryCodes
{
    [Newtonsoft.Json.JsonProperty("primaryIndustryCode")]
    public PrimaryIndustryCode? PrimaryIndustryCode { get; set; }
    public List<object>? OtherIndustryCodes { get; set; }
}


