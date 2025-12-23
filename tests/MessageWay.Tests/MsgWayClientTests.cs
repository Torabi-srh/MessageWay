using System.Net;
using System.Text.Json;
using MessageWay.Core.Models;
using Moq;
using Moq.Protected;

namespace MessageWay.Tests;

public class MsgWayClientTests
{
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly HttpClient _httpClient;
    private readonly MsgWayOptions _options;

    public MsgWayClientTests()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        _options = new MsgWayOptions { ApiKey = "test-key" };
    }

    [Fact]
    public async Task SendAsync_SendsCorrectRequest_AndReturnsResponse()
    {
        // Arrange
        var request = new SendRequest
        {
            Mobile = "09123456789",
            Method = SendMethod.Sms,
            TemplateId = 123
        };
        var expectedResponse = new SendResponse { Status = "success", ReferenceId = "ref123" };

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post &&
                    req.RequestUri!.ToString().EndsWith("send") &&
                    req.Headers.Contains("apiKey") &&
                    req.Headers.GetValues("apiKey").First() == "test-key"),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        var client = new MsgWayClient(_httpClient, _options);

        // Act
        var result = await client.SendAsync(request);

        // Assert
        Assert.Equal("success", result.Status);
        Assert.Equal("ref123", result.ReferenceId);
    }

    [Fact]
    public async Task GetBalanceAsync_SendsCorrectRequest_AndReturnsResponse()
    {
        // Arrange
        var expectedResponse = new BalanceResponse { Balance = 1000 };

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri!.ToString().EndsWith("balance/get")),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        var client = new MsgWayClient(_httpClient, _options);

        // Act
        var result = await client.GetBalanceAsync();

        // Assert
        Assert.Equal(1000, result.Balance);
    }
}
