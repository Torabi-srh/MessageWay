using System.Text.Json.Serialization;

namespace MessageWay.Core.Models;

/// <summary>
/// Represents the response for a status check.
/// </summary>
public class StatusResponse
{
    /// <summary>
    /// Gets or sets the status of the message.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    
    // Add other fields if known, for now generic status
}
