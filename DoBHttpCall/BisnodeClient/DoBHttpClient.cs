using DoBHttpCall.Responses.CompanyInformationResponses;
using DoBHttpCall.Responses.Tokens;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace DoBHttpCall.Clients;

public class DoBHttpClient : IDoBHttpClient
{
    private static readonly string[] Segments = ["COMPANY_INFORMATION"];
    private static readonly string BisnodeTokenEndpoint = "https://login.bisnode.com/sandbox/v1/token.oauth2";
    private static readonly string BisnodeCompanyInformationEndpoint = "https://sandbox-api.bisnode.com/credit-data-companies/v2/companies/se";
    private readonly HttpClient _httpClient;
    private readonly string _clientId;
    private readonly string _clientSecret;

    public DoBHttpClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;

        _clientId = configuration["Bisnode:ClientId"] ?? throw new InvalidOperationException("Bisnode:ClientId saknas.");

        _clientSecret = configuration["Bisnode:ClientSecret"] ?? throw new InvalidOperationException("Bisnode:ClientSecret saknas.");
    }

    public async Task<CompanyInformationRoot> GetCompanyInformation(string registrationNumber, CancellationToken cancellationToken = default)
    {
        var accessToken = await GetAccessToken(cancellationToken);

        using var request = new HttpRequestMessage(HttpMethod.Post, BisnodeCompanyInformationEndpoint);

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        request.Content = JsonContent.Create(new
        {
            registrationNumber,
            language = "EN",
            segments = Segments
        });

        var response = await _httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonConvert.DeserializeObject<CompanyInformationRoot>(json) ?? throw new InvalidOperationException("Kunde inte läsa CompanyInformation-svaret.");
    }


    private async Task<string> GetAccessToken(CancellationToken cancellationToken)
    {
        var credentials = $"{_clientId}:{_clientSecret}";
        var base64Credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
        using var request = new HttpRequestMessage(HttpMethod.Post, BisnodeTokenEndpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);
        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["grant_type"] = "client_credentials",
            ["scope"] = "credit_data_companies"
        });

        var response = await _httpClient.SendAsync(request, cancellationToken);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);

        var tokenResponse = JsonConvert.DeserializeObject<DoBTokenResponse>(json) ?? throw new InvalidOperationException("Kunde inte läsa token-svaret.");

        return tokenResponse.access_token ?? throw new InvalidOperationException("access_token saknas i token-svaret.");
    }
}