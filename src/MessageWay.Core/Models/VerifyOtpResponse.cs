using System.Text.Json.Serialization;

namespace MessageWay.Core.Models;

/// <summary>
/// Represents the response for an OTP verification.
/// </summary>
public class VerifyOtpResponse
{
    /// <summary>
    /// Gets or sets a value indicating whether the verification was successful.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    
    // Add validation specific fields if needed
}
