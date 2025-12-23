using System.Text.Json.Serialization;

namespace MessageWay.Core.Models;

/// <summary>
/// Represents a request to check message status.
/// </summary>
public class StatusRequest
{
    /// <summary>
    /// Gets or sets the OTP Reference ID.
    /// </summary>
    [JsonPropertyName("OTPReferenceID")]
    public string OtpReferenceId { get; set; } = string.Empty;
}
