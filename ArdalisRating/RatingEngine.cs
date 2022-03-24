namespace ArdalisRating;

/// <summary>
/// The RatingEngine reads the policy application details from a file and produces a numeric 
/// rating value based on the details.
/// </summary>
public class RatingEngine
{
    public decimal Rating { get; set; }
    
    public ConsoleLogger Logger { get; set; } = new();
    public TextPolicySource PolicySource { get; set; } = new();
    public JsonPolicySerializer PolicySerializer { get; set; } = new();

    public void Rate()
    {
        Logger.Log("Starting rate.");
        Logger.Log("Loading policy.");

        var policyJson = PolicySource.GetPolicyFromSource("policy.json");
        var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

        switch (policy.Type)
        {
            case PolicyType.Auto:
                var rater = new AutoPolicyRater(this, Logger);
                rater.Rate(policy);
                break;

            case PolicyType.Land:
                var rater2 = new LandPolicyRater(this, Logger);
                rater2.Rate(policy);
                break;

            case PolicyType.Life:
                var rater3 = new LandPolicyRater(this, Logger);
                rater3.Rate(policy);
                break;

            default:
                Logger.Log("Unknown policy type");
                break;
        }

        Logger.Log("Rating completed.");
    }
}