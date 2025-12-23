namespace MessageWay;

/// <summary>
/// Configuration options for MsgWay.
/// </summary>
public class MsgWayOptions
{
    /// <summary>
    /// Gets or sets the API Key.
    /// </summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Base URL. Defaults to https://api.msgway.com.
    /// </summary>
    public string BaseUrl { get; set; } = "https://api.msgway.com";

    /// <summary>
    /// Gets or sets the language. Defaults to "fa".
    /// </summary>
    public string Language { get; set; } = "fa";
}
