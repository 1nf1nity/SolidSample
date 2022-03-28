namespace ArdalisRating.PolicySources;

public class TextPolicySource : IPolicySource
{
    public string GetPolicyFromSource(string filepath)
    {
        return File.ReadAllText(filepath);
    }
}