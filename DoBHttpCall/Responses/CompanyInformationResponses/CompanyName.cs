namespace DoBHttpCall.Responses.CompanyInformationResponses;

public class CompanyName
{
    public List<object>? SecondaryNames { get; set; }
    public List<object>? AlternativeNames { get; set; }
    public List<HistoricalName>? HistoricalNames { get; set; }
    public RegisteredName? RegisteredName { get; set; }
}
