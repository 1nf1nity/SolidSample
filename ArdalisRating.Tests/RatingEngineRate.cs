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
    private readonly Mock<IPolicySource> _policySourceMock = new();
    private readonly Mock<IPolicySerializer> _policySerializerMock = new();

    public RatingEngineRate()
    {
        _sut = new RatingEngine(_loggerMock.Object, _policySourceMock.Object, _policySerializerMock.Object);
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
        string json = @"{
  ""type"": ""Land"",
  ""bondAmount"": ""200000"",
  ""valuation"": ""200000""
}
";
        _policySourceMock.Setup(m => m.GetPolicyFromSource(It.IsAny<string>())).Returns(json);
        _policySerializerMock.Setup(m => m.GetPolicyFromString(It.IsAny<string>())).Returns(policy);

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
        string json = @"{
  ""bondAmount"": ""200000"",
  ""valuation"": ""260000""
}
";
        _policySourceMock.Setup(m => m.GetPolicyFromSource(It.IsAny<string>())).Returns(json);
        _policySerializerMock.Setup(m => m.GetPolicyFromString(It.IsAny<string>())).Returns(policy);


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
        string json = @"{
  ""type"": ""Land"",
  ""bondAmount"": ""200000"",
  ""valuation"": ""260000""
}
";
        _policySourceMock.Setup(m => m.GetPolicyFromSource(It.IsAny<string>())).Returns(json);
        _policySerializerMock.Setup(m => m.GetPolicyFromString(It.IsAny<string>())).Returns(policy);

        _sut.Rate();

        _loggerMock.Verify(m => m.Log("Starting rate."));
        _loggerMock.Verify(m => m.Log("Loading policy."));
        _loggerMock.Verify(m => m.Log("Rating completed."));
    }
}