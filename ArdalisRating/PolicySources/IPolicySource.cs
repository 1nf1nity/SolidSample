namespace ArdalisRating.PolicySources;

public interface IPolicySource
{
    string GetPolicyFromSource(string filepath);
}