namespace ArdalisRating;

public class TextPolicySource
{
    public string GetPolicyFromSource(string filepath)
    {
        return File.ReadAllText(filepath);
    }
}