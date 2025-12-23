using System.Text.Json.Serialization;

namespace MessageWay.Core.Models;

/// <summary>
/// Represents the template response.
/// </summary>
public class TemplateResponse
{
    /// <summary>
    /// Gets or sets the template ID.
    /// </summary>
    [JsonPropertyName("templateID")]
    public int TemplateId { get; set; }

    /// <summary>
    /// Gets or sets the template body.
    /// </summary>
    [JsonPropertyName("body")]
    public string? Body { get; set; }
}
