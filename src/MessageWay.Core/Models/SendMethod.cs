using System.Text.Json.Serialization;

namespace MessageWay.Core.Models;

/// <summary>
/// Represents the method used for sending the message.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SendMethod
{
    /// <summary>
    /// Send via SMS.
    /// </summary>
    [JsonPropertyName("sms")]
    Sms,

    /// <summary>
    /// Send via Interactive Voice Response (IVR).
    /// </summary>
    [JsonPropertyName("ivr")]
    Ivr,

    /// <summary>
    /// Send via a messenger app.
    /// </summary>
    [JsonPropertyName("messenger")]
    Messenger
}
