namespace DoBHttpCall.Responses.Tokens;

public sealed class DoBTokenResponse
{
    [Newtonsoft.Json.JsonProperty("access_token")]
    public string? AccessToken { get; set; }

    [Newtonsoft.Json.JsonProperty("scope")]
    public string? Scope { get; set; }

    [Newtonsoft.Json.JsonProperty("token_type")]
    public string? TokenType { get; set; }

    [Newtonsoft.Json.JsonProperty("expires_in")]
    public int? ExpiresIn { get; set; }
}
