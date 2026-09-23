namespace DoBHttpCall.Responses.CompanyInformationResponses;

public class CompanyInformation
{
    public Capital? Capital { get; set; }
    public Identifiers? Identifiers { get; set; }
    public IndustryCodeSet? IndustryCodeSet { get; set; }
    public CompanyName? CompanyName { get; set; }
    public ContactPoints? ContactPoints { get; set; }
    public RegistrationInformation? RegistrationInformation { get; set; }
    public GeneralCompanyData? GeneralCompanyData { get; set; }
    public List<object> BankgiroAccounts { get; set; } = [];
    public Branch? Branches { get; set; }
    public LegalForm? LegalForm { get; set; }
    public Status? Status { get; set; }
}


