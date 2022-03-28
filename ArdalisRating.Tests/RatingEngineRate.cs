using Newtonsoft.Json;
using System.IO;
using FluentAssertions;
using Xunit;

namespace ArdalisRating.Tests;

public class RatingEngineRate
{
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

        var engine = new RatingEngine();
        engine.Rate();
        var result = engine.Rating;

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

        var engine = new RatingEngine();
        engine.Rate();
        var result = engine.Rating;

        result.Should().Be(0);
    }
}