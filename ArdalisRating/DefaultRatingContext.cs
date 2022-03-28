﻿namespace ArdalisRating;

public class DefaultRatingContext : IRatingContext
{
    private readonly IPolicySource _policySource;
    private readonly IPolicySerializer _policySerializer;

    public RatingEngine Engine { get; set; }

    public DefaultRatingContext(IPolicySource policySource, IPolicySerializer policySerializer)
    {
        _policySource = policySource;
        _policySerializer = policySerializer;
    }

    public Rater CreateRaterForPolicy(Policy policy, IRatingContext context)
    {
        return new RaterFactory().Create(policy, context);
    }

    public Policy GetPolicyFromJsonString(string policyJson)
    {
        return _policySerializer.GetPolicyFromString(policyJson);
    }

    public Policy GetPolicyFromXmlString(string policyXml)
    {
        throw new NotImplementedException();
    }

    public string LoadPolicyFromFile(string filepath)
    {
        return _policySource.GetPolicyFromSource(filepath);
    }

    public string LoadPolicyFromUri(string uri)
    {
        throw new NotImplementedException();
    }

    public void Log(string message)
    {
        new ConsoleLogger().Log(message);
    }

    public void UpdateRating(decimal rating)
    {
        Engine.Rating = rating;
    }
}