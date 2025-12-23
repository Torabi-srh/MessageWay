using System.Text.Json.Serialization;

namespace MessageWay.Core.Models;

/// <summary>
/// Represents a request to get a template.
/// </summary>
public class TemplateRequest
{
    /// <summary>
    /// Gets or sets the template ID.
    /// </summary>
    [JsonPropertyName("templateID")]
    public int TemplateId { get; set; }
}
