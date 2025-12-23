using MessageWay.Core.Models;

namespace MessageWay.Core;

/// <summary>
/// Defines the contract for interacting with the MsgWay API.
/// </summary>
public interface IMsgWayClient
{
    /// <summary>
    /// Sends a message using the specified request.
    /// </summary>
    /// <param name="request">The send request details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The response from the send operation.</returns>
    Task<SendResponse> SendAsync(SendRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the status of a message.
    /// </summary>
    /// <param name="request">The status request details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The status response.</returns>
    Task<StatusResponse> GetStatusAsync(StatusRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Verifies an OTP code.
    /// </summary>
    /// <param name="request">The verification request details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The verification response.</returns>
    Task<VerifyOtpResponse> VerifyOtpAsync(VerifyOtpRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the current account balance.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The balance response.</returns>
    Task<BalanceResponse> GetBalanceAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a template by its ID.
    /// </summary>
    /// <param name="request">The template request details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The template response.</returns>
    Task<TemplateResponse> GetTemplateAsync(TemplateRequest request, CancellationToken cancellationToken = default);
}
