using Newtonsoft.Json;
using System.IO;
using FluentAssertions;
using Moq;
using Xunit;

namespace ArdalisRating.Tests;

public class RatingEngineRate
{
    private readonly RatingEngine _sut;
    private readonly Mock<ILogger> _loggerMock = new();

    public RatingEngineRate()
    {
        _sut = new RatingEngine(_loggerMock.Object);
    }

    [Fact]
    public void ReturnsRatingOf10000For200000LandPolicy()
    {
        var policy = new Policy
        {
            Type = PolicyType.Land,
            BondAmount = 200000,
            Valuation = 200000
        };
        string json = JsonConvert.SerializeObject(policy);
        File.WriteAllText("policy.json", json);

        _sut.Rate();
        var result = _sut.Rating;

        result.Should().Be(10000);
    }

    [Fact]
    public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
    {
        var policy = new Policy
        {
            BondAmount = 200000,
            Valuation = 260000
        };
        string json = JsonConvert.SerializeObject(policy);
        File.WriteAllText("policy.json", json);

        _sut.Rate();
        var result = _sut.Rating;

        result.Should().Be(0);
    }

    [Fact]
    public void LogsStartingLoadingAndCompleting()
    {
        var policy = new Policy
        {
            Type = PolicyType.Land,
            BondAmount = 200000,
            Valuation = 260000
        };
        string json = JsonConvert.SerializeObject(policy);
        File.WriteAllText("policy.json", json);

        _sut.Rate();

        _loggerMock.Verify(m => m.Log("Starting rate."));
        _loggerMock.Verify(m => m.Log("Loading policy."));
        _loggerMock.Verify(m => m.Log("Rating completed."));
    }
}