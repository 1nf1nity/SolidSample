namespace ArdalisRating;

/// <summary>
/// The RatingEngine reads the policy application details from a file and produces a numeric 
/// rating value based on the details.
/// </summary>
public class RatingEngine
{
    public decimal Rating { get; set; }

    protected IRatingContext Context { get; set; } = new DefaultRatingContext();

    public RatingEngine()
    {
        Context.Engine = this;
    }

    public void Rate()
    {
        Context.Log("Starting rate.");
        Context.Log("Loading policy.");

        var policyJson = Context.LoadPolicyFromFile("policy.json");
        var policy = Context.GetPolicyFromJsonString(policyJson);

        var rater = Context.CreateRaterForPolicy(policy, Context);
        rater.Rate(policy);

        Context.Log("Rating completed.");
    }
}