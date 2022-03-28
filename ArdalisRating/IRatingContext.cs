namespace ArdalisRating;

public interface IRatingContext : ILogger
{
    string LoadPolicyFromFile(string filepath);
    string LoadPolicyFromUri(string uri);
    Policy GetPolicyFromJsonString(string policyJson);
    Policy GetPolicyFromXmlString(string policyXml);
    Rater CreateRaterForPolicy(Policy policy, IRatingContext context);
    void UpdateRating(decimal rating);
    RatingEngine Engine { get; set; }
    ConsoleLogger Logger { get; }
}