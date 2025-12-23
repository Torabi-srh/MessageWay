using System.Text.Json.Serialization;

namespace MessageWay.Core.Models;

/// <summary>
/// Represents the response from a send request.
/// </summary>
public class SendResponse
{
    /// <summary>
    /// Gets or sets the status of the request.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// Gets or sets the reference ID for the OTP/Message.
    /// </summary>
    [JsonPropertyName("referenceID")]
    public string? ReferenceId { get; set; }
    
    /// <summary>
    /// Gets or sets the error message if any.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }
}
