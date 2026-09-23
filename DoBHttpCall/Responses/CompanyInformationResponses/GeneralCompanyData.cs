namespace DoBHttpCall.Responses.CompanyInformationResponses;

public class GeneralCompanyData
{
    public bool ActiveInVat { get; set; }
    public List<object>? AlcoholServicePermits { get; set; }
    public bool? CorporateTax { get; set; }
    public string? CountryCode { get; set; }
    public string? Location { get; set; }
    public bool? RegisteredInVatList { get; set; }
    public bool? OffTheShelfCompany { get; set; }
    public int? EmployeeCount { get; set; }
    public ActiveInVatStatusDate? ActiveInVatStatusDate { get; set; }
    public bool? RegisteredAsEmployer { get; set; }
    public string? OfficeType { get; set; }
}


