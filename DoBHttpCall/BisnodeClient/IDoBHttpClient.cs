using DoBHttpCall.Responses.CompanyInformationResponses;

namespace DoBHttpCall.Clients;

public interface IDoBHttpClient
{
    Task<CompanyInformationRoot> GetCompanyInformation(string registrationNumber, CancellationToken cancellationToken = default);
}
