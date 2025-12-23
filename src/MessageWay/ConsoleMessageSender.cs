using MessageWay.Core;

namespace MessageWay;

/// <summary>
/// A simple message sender that writes to the console.
/// </summary>
public class ConsoleMessageSender : IMessageSender
{
    /// <inheritdoc />
    public Task SendAsync(string message, CancellationToken cancellationToken = default)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        Console.WriteLine($"Sending message: {message}");
        return Task.CompletedTask;
    }
}
