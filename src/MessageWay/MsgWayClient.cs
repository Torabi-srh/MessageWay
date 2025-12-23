using System.Net.Http.Json;
using System.Text.Json;
using MessageWay.Core;
using MessageWay.Core.Models;

namespace MessageWay;

/// <summary>
/// Implementation of the MsgWay client.
/// </summary>
public class MsgWayClient : IMsgWayClient
{
    private readonly HttpClient _httpClient;
    private readonly MsgWayOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="MsgWayClient"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    /// <param name="options">The configuration options.</param>
    public MsgWayClient(HttpClient httpClient, MsgWayOptions options)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _options = options ?? throw new ArgumentNullException(nameof(options));

        if (string.IsNullOrWhiteSpace(_options.ApiKey))
        {
            throw new ArgumentException("ApiKey must be provided in options.", nameof(options));
        }

        ConfigureHttpClient();
    }

    private void ConfigureHttpClient()
    {
        _httpClient.BaseAddress = new Uri(_options.BaseUrl);
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("apiKey", _options.ApiKey);
        _httpClient.DefaultRequestHeaders.Add("accept-language", _options.Language);
    }

    /// <inheritdoc />
    public async Task<SendResponse> SendAsync(SendRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync("send", request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<SendResponse>(cancellationToken: cancellationToken) 
               ?? new SendResponse { Status = "Unknown", Error = "Empty response" };
    }

    /// <inheritdoc />
    public async Task<StatusResponse> GetStatusAsync(StatusRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync("status", request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<StatusResponse>(cancellationToken: cancellationToken)
               ?? new StatusResponse { Status = "Unknown" };
    }

    /// <inheritdoc />
    public async Task<VerifyOtpResponse> VerifyOtpAsync(VerifyOtpRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync("otp/verify", request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<VerifyOtpResponse>(cancellationToken: cancellationToken)
               ?? new VerifyOtpResponse { Status = "Unknown" };
    }

    /// <inheritdoc />
    public async Task<BalanceResponse> GetBalanceAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("balance/get", cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<BalanceResponse>(cancellationToken: cancellationToken)
               ?? new BalanceResponse();
    }

    /// <inheritdoc />
    public async Task<TemplateResponse> GetTemplateAsync(TemplateRequest request, CancellationToken cancellationToken = default)
    {
        // Docs: curl ... --data '{ "templateID": 282 }'
        // So this is POST.
        var response = await _httpClient.PostAsJsonAsync("template/get", request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TemplateResponse>(cancellationToken: cancellationToken)
               ?? new TemplateResponse();
    }
}
