using Moq;
using Xunit;

namespace ArdalisRating.Tests;

public class AutoPolicyRate
{
    private readonly AutoPolicyRater _sut;

    private readonly Mock<ILogger> _loggerMock = new();
    private readonly Mock<IRatingUpdater> _ratingUpdaterMock = new();

    public AutoPolicyRate()
    {
        _sut = new (_ratingUpdaterMock.Object);
        _sut.Logger = _loggerMock.Object;
    }

    [Fact]
    public void LogsMakeRequiredMessageGivenPolicyWithoutMake()
    {
        var policy = new Policy() { Type = PolicyType.Auto };

        _sut.Rate(policy);

        _loggerMock.Verify(m => m.Log("Auto policy must specify Make"));
    }

    [Fact]
    public void SetsRatingTo1000ForBmwWith250Deductible()
    {
        var policy = new Policy()
        {
            Type = PolicyType.Auto,
            Make = "BMW",
            Deductible = 250m
        };

        _sut.Rate(policy);

        _ratingUpdaterMock.Verify(m => m.UpdateRating(1000m));
    }

    [Fact]
    public void SetsRatingTo900ForBmwWith500Deductible()
    {
        var policy = new Policy()
        {
            Type = PolicyType.Auto,
            Make = "BMW",
            Deductible = 500m
        };

        _sut.Rate(policy);

        _ratingUpdaterMock.Verify(m => m.UpdateRating(900m));
    }
}