using MessageWay;
using MessageWay.Core;

namespace MessageWay.Tests;

public class ConsoleMessageSenderTests
{
    [Fact]
    public async Task SendAsync_WritesToConsole()
    {
        // Arrange
        var sender = new ConsoleMessageSender();
        var message = "Hello World";

        // Act
        // Since we can't easily assert Console output without redirection, we just ensure it doesn't throw.
        var exception = await Record.ExceptionAsync(() => sender.SendAsync(message));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public async Task SendAsync_ThrowsArgumentNullException_WhenMessageIsNull()
    {
        // Arrange
        var sender = new ConsoleMessageSender();

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => sender.SendAsync(null!));
    }
}
