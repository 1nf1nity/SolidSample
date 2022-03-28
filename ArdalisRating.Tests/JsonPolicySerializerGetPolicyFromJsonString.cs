using ArdalisRating.Models;
using ArdalisRating.PolicySerializers;
using FluentAssertions;
using Xunit;

namespace ArdalisRating.Tests;

public class JsonPolicySerializerGetPolicyFromJsonString
{
    [Fact]
    public void ReturnsDefaultPolicyFromEmptyJsonString()
    {
        var inputJson = "{}";
        var serializer = new JsonPolicySerializer();

        var result = serializer.GetPolicyFromString(inputJson);

        var policy = new Policy();
        result.Should().BeEquivalentTo(policy);
    }

    [Fact]
    public void ReturnsSimpleAutoPolicyFromValidJsonString()
    {
        var inputJson = @"{
  ""type"": ""Auto"",
  ""make"": ""BMW""
}
";
        var serializer = new JsonPolicySerializer();

        var result = serializer.GetPolicyFromString(inputJson);

        var policy = new Policy
        {
            Type = PolicyType.Auto,
            Make = "BMW"
        };
        result.Should().BeEquivalentTo(policy);
    }
}