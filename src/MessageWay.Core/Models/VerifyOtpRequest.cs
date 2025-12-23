using System.Text.Json.Serialization;

namespace MessageWay.Core.Models;

/// <summary>
/// Represents a request to verify an OTP.
/// </summary>
public class VerifyOtpRequest
{
    /// <summary>
    /// Gets or sets the mobile number.
    /// </summary>
    [JsonPropertyName("mobile")]
    public string Mobile { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the OTP code.
    /// </summary>
    [JsonPropertyName("OTP")]
    public string Otp { get; set; } = string.Empty;
}
