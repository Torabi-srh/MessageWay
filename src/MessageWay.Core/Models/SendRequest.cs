using System.Text.Json.Serialization;

namespace MessageWay.Core.Models;

/// <summary>
/// Represents a request to send a message.
/// </summary>
public class SendRequest
{
    /// <summary>
    /// Gets or sets the mobile number.
    /// </summary>
    [JsonPropertyName("mobile")]
    public string Mobile { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the method of sending.
    /// </summary>
    [JsonPropertyName("method")]
    public SendMethod Method { get; set; }

    /// <summary>
    /// Gets or sets the template ID.
    /// </summary>
    [JsonPropertyName("templateID")]
    public int TemplateId { get; set; }

    /// <summary>
    /// Gets or sets the optional OTP code.
    /// </summary>
    [JsonPropertyName("code")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Code { get; set; }

    /// <summary>
    /// Gets or sets the optional parameters for the template.
    /// </summary>
    [JsonPropertyName("params")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? Params { get; set; }

    /// <summary>
    /// Gets or sets the provider (required for Messenger method).
    /// </summary>
    [JsonPropertyName("provider")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MessengerProvider? Provider { get; set; }
}
