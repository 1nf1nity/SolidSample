namespace ArdalisRating;

public interface IPolicySource
{
    string GetPolicyFromSource(string filepath);
}