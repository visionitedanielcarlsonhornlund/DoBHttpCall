namespace DoBHttpCall.Responses.CompanyInformationResponses;

public class Branch
{
    public Address? Address { get; set; }
    public Identifiers? Identifiers { get; set; }
    public string? OfficeNumber  { get; set; }
    public bool? HeadQuarter { get; set; }
    public List<Branch>? Ranches { get; set; }
}


