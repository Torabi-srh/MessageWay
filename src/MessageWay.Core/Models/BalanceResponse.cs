using System.Text.Json.Serialization;

namespace MessageWay.Core.Models;

/// <summary>
/// Represents the account balance response.
/// </summary>
public class BalanceResponse
{
    /// <summary>
    /// Gets or sets the balance.
    /// </summary>
    [JsonPropertyName("balance")]
    public decimal Balance { get; set; }
}
