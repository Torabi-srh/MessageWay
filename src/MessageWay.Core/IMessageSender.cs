namespace MessageWay.Core;

/// <summary>
/// Defines a contract for sending messages.
/// </summary>
public interface IMessageSender
{
    /// <summary>
    /// Sends a message asynchronously.
    /// </summary>
    /// <param name="message">The message content.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SendAsync(string message, CancellationToken cancellationToken = default);
}
